using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Servicios.Interfaces;
using Google.Cloud.Storage.V1;
using Google.Apis.Auth.OAuth2;

namespace Servicios.Servicios
{
    public class Productos:IProductos
    {
        private readonly DataBaseContext _dataBaseContext;
        private readonly Errores _errores;
        private readonly string bucket = "desa-web-final";
        private readonly string urlBucket = "https://storage.googleapis.com/";
        public Productos(DataBaseContext ctx)
        {
            _dataBaseContext = ctx;
            _errores = new Errores();
        }

        public async Task<IActionResult> CrearProducto(Producto prod)
        {
            try
            {
                prod.Imagen = urlBucket + bucket + "/" + prod.Nombrearchivo;
                SubirProducto(prod.Archivobase64, prod.Nombrearchivo);
                
                _dataBaseContext.Add(prod);
                prod.Archivobase64 = "";
                await _dataBaseContext.SaveChangesAsync();
                return new ObjectResult(1) { StatusCode = 200 };
            }catch(Exception ex)
            {
                return _errores.respuestaDeError("Error al momento de crear los productos",ex);
            }
        }

        public Google.Apis.Storage.v1.Data.Object SubirProducto(string base64File, string fileName)
        {
            GoogleCredential _credential = GoogleCredential.FromFile("fluent-observer-362922-a91f1ce14b90.json");
            var storage = StorageClient.Create(_credential);
            byte[] buffer = Convert.FromBase64String(base64File);
            MemoryStream stream = new MemoryStream(buffer);
            string fileTipe = "";
            if (fileName.Contains(".png"))
            {
                fileTipe = "image/png";
            } else if (fileName.Contains(".jpeg") || fileName.Contains(".jpg"))
            {
                fileTipe = "image/jpeg";
            }
            var respuesta =  storage.UploadObject(bucket, fileName, fileTipe, stream);
            
            return respuesta;
        }

        public async Task<IActionResult> ListarProductos()
        {
            try
            {
                return new ObjectResult(await _dataBaseContext.Productos.ToListAsync()) { StatusCode = 200 };
            }catch (Exception ex)
            {
                return _errores.respuestaDeError("Error al momento de listar los productos", ex);
            }
        }
        public async Task<IActionResult> BuscarProducto(string nombre)
        {
            try
            {
                var poducto = await _dataBaseContext.Productos.Where(e => e.Nombre.ToUpper().Contains(nombre.ToUpper())).ToListAsync();
                if(poducto.Count == 0)
                {
                    return _errores.respuestaDeError("El producto no fue encontrado");
                }
                return new ObjectResult(poducto) { StatusCode = 200 };
            }catch(Exception ex)
            {
                return _errores.respuestaDeError("Error al momento realizar la busqueda del producto", ex);
            }
        }
    }
}
