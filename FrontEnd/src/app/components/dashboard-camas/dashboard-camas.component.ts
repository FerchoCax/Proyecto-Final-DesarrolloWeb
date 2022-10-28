import { Component, OnInit, OnDestroy } from '@angular/core';
import { Sucursale } from 'src/app/services/api-backend';
import { CamaService } from 'src/app/services/api-backend/api/cama.service';
import { SucursalesService } from 'src/app/services/api-backend/api/sucursales.service';
import { CamasSocketService } from './camasSocket.service';

@Component({
  selector: 'app-dashboard-camas',
  templateUrl: './dashboard-camas.component.html',
  styleUrls: ['./dashboard-camas.component.scss']
})
export class DashboardCamasComponent implements OnInit,OnDestroy {
  dataSucursal:Sucursale[]=[];
  IdSucursal:string = '-';
  Sucursal:Sucursale;
  constructor(private socketCamas:CamasSocketService,
    private servicioSucursales: SucursalesService,
    private camaservices: CamaService) 
  {
    // this.socketCamas.infoCamas.subscribe(res =>{
    //   console.log(res)
    // })
  }

  ngOnInit(): void {
    this.cargarSucursales()
  } 
  Dato:string = '----';
  CambioSucursal(){
    if(this.IdSucursal =='-'){
      return
    }
    this.camaservices.camaSalasSucursalGet(this.IdSucursal)
    .subscribe(res =>{
      this.Sucursal = <Sucursale>res[0]
    },error =>{
      console.log(error)
    })
    console.log(this.socketCamas)
    if(this.socketCamas.iniciado){
      this.socketCamas.detener();
    }
    console.log(this.socketCamas.iniciado)

    this.socketCamas.iniciar(this.IdSucursal)
    console.log(this.socketCamas.iniciado)

    console.log(this.socketCamas)
    this.socketCamas.infoCamas.subscribe(res =>{
      console.log(res);
      this.Sucursal = <Sucursale>res[0]
      console.log(this.Sucursal);
      
      
    },error=>{
      console.log(error);
      
    })
   
  }
  
  cargarSucursales(){
    this.servicioSucursales.sucursalesGetSucursalesGet()
    .subscribe(res=>{
      this.dataSucursal = <Sucursale[]>res
      // console.log(this.dataSucursal)
    }),error=>{
      console.log(error);
    }
  }

  ngOnDestroy(){
    this.socketCamas.detener();
  }

}
