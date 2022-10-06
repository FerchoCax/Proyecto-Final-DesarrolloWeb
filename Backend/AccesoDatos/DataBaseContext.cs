using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace AccesoDatos
{
    public partial class DataBaseContext : DbContext
    {
        public DataBaseContext()
        {
        }

        public DataBaseContext(DbContextOptions<DataBaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AplicacionesMedicamento> AplicacionesMedicamentos { get; set; }
        public virtual DbSet<AsignacionesCama> AsignacionesCamas { get; set; }
        public virtual DbSet<Bodega> Bodegas { get; set; }
        public virtual DbSet<Cama> Camas { get; set; }
        public virtual DbSet<Caso> Casos { get; set; }
        public virtual DbSet<Cita> Citas { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Clinica> Clinicas { get; set; }
        public virtual DbSet<Departamento> Departamentos { get; set; }
        public virtual DbSet<Diagnostico> Diagnosticos { get; set; }
        public virtual DbSet<DiagnosticosCaso> DiagnosticosCasos { get; set; }
        public virtual DbSet<DiagnosticosCitum> DiagnosticosCita { get; set; }
        public virtual DbSet<Examene> Examenes { get; set; }
        public virtual DbSet<ExamenesCaso> ExamenesCasos { get; set; }
        public virtual DbSet<Factura> Facturas { get; set; }
        public virtual DbSet<Habitacione> Habitaciones { get; set; }
        public virtual DbSet<HistoriasClinica> HistoriasClinicas { get; set; }
        public virtual DbSet<Lote> Lotes { get; set; }
        public virtual DbSet<MedicamentosCaso> MedicamentosCasos { get; set; }
        public virtual DbSet<MedicamentosRecetum> MedicamentosReceta { get; set; }
        public virtual DbSet<Municipio> Municipios { get; set; }
        public virtual DbSet<Paciente> Pacientes { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<ProductosFactura> ProductosFacturas { get; set; }
        public virtual DbSet<Receta> Recetas { get; set; }
        public virtual DbSet<ResultadoExamene> ResultadoExamenes { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<RolesUsuario> RolesUsuarios { get; set; }
        public virtual DbSet<Sucursale> Sucursales { get; set; }
        public virtual DbSet<TiposHabitacion> TiposHabitacions { get; set; }
        public virtual DbSet<TiposUsuario> TiposUsuarios { get; set; }
        public virtual DbSet<TiposVentum> TiposVenta { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Venta> Ventas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("Server=34.132.2.235;Database=db_clinica;Uid=Fernando;Pwd=marceline1;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AplicacionesMedicamento>(entity =>
            {
                entity.HasKey(e => e.IdAplicacionMedicamento)
                    .HasName("PRIMARY");

                entity.ToTable("aplicaciones_medicamentos");

                entity.HasIndex(e => e.IdLote, "FK_ID_LOTE_APLIC_MEDS_idx");

                entity.HasIndex(e => e.IdMedicamentosCaso, "FK_ID_MEDICS_CASO_APLI_MEDS_idx");

                entity.HasIndex(e => e.IdUsuario, "FK_ID_USUARIO_APLIC_MEDS_idx");

                entity.Property(e => e.IdAplicacionMedicamento).HasColumnName("id_aplicacion_medicamento");

                entity.Property(e => e.FechaHoraAplicacion).HasColumnName("fecha_hora_aplicacion");

                entity.Property(e => e.IdLote).HasColumnName("id_lote");

                entity.Property(e => e.IdMedicamentosCaso).HasColumnName("id_medicamentos_caso");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.HasOne(d => d.IdLoteNavigation)
                    .WithMany(p => p.AplicacionesMedicamentos)
                    .HasForeignKey(d => d.IdLote)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_LOTE_APLIC_MEDS");

                entity.HasOne(d => d.IdMedicamentosCasoNavigation)
                    .WithMany(p => p.AplicacionesMedicamentos)
                    .HasForeignKey(d => d.IdMedicamentosCaso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_MEDICS_CASO_APLI_MEDS");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.AplicacionesMedicamentos)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_USUARIO_APLIC_MEDS");
            });

            modelBuilder.Entity<AsignacionesCama>(entity =>
            {
                entity.HasKey(e => e.IdAsignacionCama)
                    .HasName("PRIMARY");

                entity.ToTable("asignaciones_cama");

                entity.HasIndex(e => e.IdCama, "FK_ID_CAMA_ASIG_CAMA_idx");

                entity.HasIndex(e => e.IdCaso, "FK_ID_CASO_ASIG_CAMAS_idx");

                entity.Property(e => e.IdAsignacionCama).HasColumnName("id_asignacion_cama");

                entity.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .HasColumnName("estado")
                    .HasDefaultValueSql("'A'");

                entity.Property(e => e.FechaFin).HasColumnName("fecha_fin");

                entity.Property(e => e.FechaInicio).HasColumnName("fecha_inicio");

                entity.Property(e => e.IdCama).HasColumnName("id_cama");

                entity.Property(e => e.IdCaso).HasColumnName("id_caso");

                entity.HasOne(d => d.IdCamaNavigation)
                    .WithMany(p => p.AsignacionesCamas)
                    .HasForeignKey(d => d.IdCama)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_CAMA_ASIG_CAMA");

                entity.HasOne(d => d.IdCasoNavigation)
                    .WithMany(p => p.AsignacionesCamas)
                    .HasForeignKey(d => d.IdCaso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_CASO_ASIG_CAMAS");
            });

            modelBuilder.Entity<Bodega>(entity =>
            {
                entity.HasKey(e => e.IdBodega)
                    .HasName("PRIMARY");

                entity.ToTable("bodegas");

                entity.HasIndex(e => e.IdSucursal, "FK_SUCURSAL_BODEGAS_idx");

                entity.Property(e => e.IdBodega).HasColumnName("id_bodega");

                entity.Property(e => e.IdSucursal).HasColumnName("id_sucursal");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("nombre");

                entity.HasOne(d => d.IdSucursalNavigation)
                    .WithMany(p => p.Bodegas)
                    .HasForeignKey(d => d.IdSucursal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SUCURSAL_BODEGAS");
            });

            modelBuilder.Entity<Cama>(entity =>
            {
                entity.HasKey(e => e.IdCama)
                    .HasName("PRIMARY");

                entity.ToTable("camas");

                entity.HasIndex(e => e.IdHabitacion, "FK_ID_HABI_CAMA_idx");

                entity.Property(e => e.IdCama).HasColumnName("id_cama");

                entity.Property(e => e.IdHabitacion).HasColumnName("id_habitacion");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .HasColumnName("nombre");

                entity.HasOne(d => d.IdHabitacionNavigation)
                    .WithMany(p => p.Camas)
                    .HasForeignKey(d => d.IdHabitacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_HABI_CAMA");
            });

            modelBuilder.Entity<Caso>(entity =>
            {
                entity.HasKey(e => e.IdCaso)
                    .HasName("PRIMARY");

                entity.ToTable("casos");

                entity.HasIndex(e => e.IdPaciente, "FK_ID_PACIENTE_CASO_idx");

                entity.Property(e => e.IdCaso).HasColumnName("id_caso");

                entity.Property(e => e.FechaFin).HasColumnName("fecha_fin");

                entity.Property(e => e.FechaInicio).HasColumnName("fecha_inicio");

                entity.Property(e => e.IdPaciente).HasColumnName("id_paciente");

                entity.Property(e => e.MotivoFinalizacion)
                    .HasMaxLength(200)
                    .HasColumnName("motivo_finalizacion");

                entity.HasOne(d => d.IdPacienteNavigation)
                    .WithMany(p => p.Casos)
                    .HasForeignKey(d => d.IdPaciente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_PACIENTE_CASO");
            });

            modelBuilder.Entity<Cita>(entity =>
            {
                entity.HasKey(e => e.IdCita)
                    .HasName("PRIMARY");

                entity.ToTable("citas");

                entity.HasIndex(e => e.IdCaso, "FK_ID_CASO_CITAS_idx");

                entity.HasIndex(e => e.IdClinica, "FK_ID_CLINICA_CITAS_idx");

                entity.HasIndex(e => e.IdUsuario, "FK_ID_USUARIO_CITA_idx");

                entity.Property(e => e.IdCita).HasColumnName("id_cita");

                entity.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .HasColumnName("estado")
                    .HasDefaultValueSql("'A'");

                entity.Property(e => e.FechaCita).HasColumnName("fecha_cita");

                entity.Property(e => e.IdCaso).HasColumnName("id_caso");

                entity.Property(e => e.IdClinica).HasColumnName("id_clinica");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.Observaciones)
                    .HasMaxLength(500)
                    .HasColumnName("observaciones");

                entity.HasOne(d => d.IdCasoNavigation)
                    .WithMany(p => p.Cita)
                    .HasForeignKey(d => d.IdCaso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_CASO_CITAS");

                entity.HasOne(d => d.IdClinicaNavigation)
                    .WithMany(p => p.Cita)
                    .HasForeignKey(d => d.IdClinica)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_CLINICA_CITAS");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Cita)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK_ID_USUARIO_CITA");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PRIMARY");

                entity.ToTable("clientes");

                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");

                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("apellidos");

                entity.Property(e => e.Correo)
                    .HasMaxLength(100)
                    .HasColumnName("correo");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(150)
                    .HasColumnName("direccion");

                entity.Property(e => e.Nit)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("nit");

                entity.Property(e => e.Nombres)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("nombres");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(100)
                    .HasColumnName("telefono");
            });

            modelBuilder.Entity<Clinica>(entity =>
            {
                entity.HasKey(e => e.IdClinica)
                    .HasName("PRIMARY");

                entity.ToTable("clinicas");

                entity.HasIndex(e => e.IdSucursal, "FK_SUCURSAL_CLINCA_idx");

                entity.Property(e => e.IdClinica).HasColumnName("id_clinica");

                entity.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .HasColumnName("estado")
                    .HasDefaultValueSql("'A'");

                entity.Property(e => e.IdSucursal).HasColumnName("id_sucursal");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .HasColumnName("nombre");

                entity.HasOne(d => d.IdSucursalNavigation)
                    .WithMany(p => p.Clinicas)
                    .HasForeignKey(d => d.IdSucursal)
                    .HasConstraintName("FK_SUCURSAL_CLINCA");
            });

            modelBuilder.Entity<Departamento>(entity =>
            {
                entity.HasKey(e => e.IdDepartamento)
                    .HasName("PRIMARY");

                entity.ToTable("departamentos");

                entity.Property(e => e.IdDepartamento).HasColumnName("id_departamento");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Diagnostico>(entity =>
            {
                entity.HasKey(e => e.IdDiagnostico)
                    .HasName("PRIMARY");

                entity.ToTable("diagnosticos");

                entity.Property(e => e.IdDiagnostico)
                    .HasMaxLength(50)
                    .HasColumnName("id_diagnostico");

                entity.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .HasColumnName("estado")
                    .HasDefaultValueSql("'A'");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<DiagnosticosCaso>(entity =>
            {
                entity.HasKey(e => e.IdDiagnostiosCaso)
                    .HasName("PRIMARY");

                entity.ToTable("diagnosticos_caso");

                entity.HasIndex(e => e.IdCaso, "FK_ID_CASO_DIAGS_CASO_idx");

                entity.HasIndex(e => e.IdDiagnostico, "FK_ID_DIAG_DIAGS_CASO");

                entity.HasIndex(e => e.IdUsuario, "FK_ID_USUARIO_DIAG_CASO_idx");

                entity.Property(e => e.IdDiagnostiosCaso).HasColumnName("id_diagnostios_caso");

                entity.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .HasColumnName("estado")
                    .HasDefaultValueSql("'A'");

                entity.Property(e => e.FechaFin).HasColumnName("fecha_fin");

                entity.Property(e => e.FechaInicio).HasColumnName("fecha_inicio");

                entity.Property(e => e.IdCaso).HasColumnName("id_caso");

                entity.Property(e => e.IdDiagnostico)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("id_diagnostico");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.Observaciones)
                    .HasMaxLength(45)
                    .HasColumnName("observaciones");

                entity.HasOne(d => d.IdCasoNavigation)
                    .WithMany(p => p.DiagnosticosCasos)
                    .HasForeignKey(d => d.IdCaso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_CASO_DIAGS_CASO");

                entity.HasOne(d => d.IdDiagnosticoNavigation)
                    .WithMany(p => p.DiagnosticosCasos)
                    .HasForeignKey(d => d.IdDiagnostico)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_DIAG_DIAGS_CASO");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.DiagnosticosCasos)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_USUARIO_DIAG_CASO");
            });

            modelBuilder.Entity<DiagnosticosCitum>(entity =>
            {
                entity.HasKey(e => e.IdDiagnosticoCita)
                    .HasName("PRIMARY");

                entity.ToTable("diagnosticos_cita");

                entity.HasIndex(e => e.IdCita, "FK_CITA_DIAG_CITA_idx");

                entity.HasIndex(e => e.IdDiagnostico, "FK_DIAG_DIAGS_CITA");

                entity.Property(e => e.IdDiagnosticoCita).HasColumnName("id_diagnostico_cita");

                entity.Property(e => e.IdCita).HasColumnName("id_cita");

                entity.Property(e => e.IdDiagnostico)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("id_diagnostico");

                entity.Property(e => e.Obresvaciones)
                    .HasMaxLength(500)
                    .HasColumnName("obresvaciones");

                entity.HasOne(d => d.IdCitaNavigation)
                    .WithMany(p => p.DiagnosticosCita)
                    .HasForeignKey(d => d.IdCita)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CITA_DIAG_CITA");

                entity.HasOne(d => d.IdDiagnosticoNavigation)
                    .WithMany(p => p.DiagnosticosCita)
                    .HasForeignKey(d => d.IdDiagnostico)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DIAG_DIAGS_CITA");
            });

            modelBuilder.Entity<Examene>(entity =>
            {
                entity.HasKey(e => e.IdExamen)
                    .HasName("PRIMARY");

                entity.ToTable("examenes");

                entity.Property(e => e.IdExamen).HasColumnName("id_examen");

                entity.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .HasColumnName("estado")
                    .HasDefaultValueSql("'A'");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<ExamenesCaso>(entity =>
            {
                entity.HasKey(e => e.IdExamenCaso)
                    .HasName("PRIMARY");

                entity.ToTable("examenes_caso");

                entity.HasIndex(e => e.IdCita, "FK_CITA_EXAMENES_CASO_idx");

                entity.HasIndex(e => e.IdExamen, "FK_EXAMEN_EXAMENES_CASO_idx");

                entity.HasIndex(e => e.IdUsuario, "FK_USUARIO_EXAMENS_CASO_idx");

                entity.Property(e => e.IdExamenCaso).HasColumnName("id_examen_caso");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(1)
                    .HasColumnName("estado")
                    .HasDefaultValueSql("'A'");

                entity.Property(e => e.IdCita).HasColumnName("id_cita");

                entity.Property(e => e.IdExamen).HasColumnName("id_examen");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.Observaciones)
                    .HasMaxLength(100)
                    .HasColumnName("observaciones");

                entity.HasOne(d => d.IdCitaNavigation)
                    .WithMany(p => p.ExamenesCasos)
                    .HasForeignKey(d => d.IdCita)
                    .HasConstraintName("FK_CITA_EXAMENES_CASO");

                entity.HasOne(d => d.IdExamenNavigation)
                    .WithMany(p => p.ExamenesCasos)
                    .HasForeignKey(d => d.IdExamen)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EXAMEN_EXAMENES_CASO");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.ExamenesCasos)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USUARIO_EXAMENS_CASO");
            });

            modelBuilder.Entity<Factura>(entity =>
            {
                entity.HasKey(e => e.IdFactura)
                    .HasName("PRIMARY");

                entity.ToTable("facturas");

                entity.Property(e => e.IdFactura).HasColumnName("id_factura");

                entity.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .HasColumnName("estado")
                    .HasDefaultValueSql("'A'");

                entity.Property(e => e.FechaFactura).HasColumnName("fecha_factura");

                entity.Property(e => e.TotalFactura).HasColumnName("total_factura");
            });

            modelBuilder.Entity<Habitacione>(entity =>
            {
                entity.HasKey(e => e.IdHabitacion)
                    .HasName("PRIMARY");

                entity.ToTable("habitaciones");

                entity.HasIndex(e => e.IdTipoHabitacion, "FK_ID_TIPOH_HABI_idx");

                entity.HasIndex(e => e.IdSucursal, "FK_SUCURSAL_HABI_idx");

                entity.Property(e => e.IdHabitacion).HasColumnName("id_habitacion");

                entity.Property(e => e.IdSucursal).HasColumnName("id_sucursal");

                entity.Property(e => e.IdTipoHabitacion).HasColumnName("id_tipo_habitacion");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .HasColumnName("nombre");

                entity.HasOne(d => d.IdSucursalNavigation)
                    .WithMany(p => p.Habitaciones)
                    .HasForeignKey(d => d.IdSucursal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SUCURSAL_HABI");

                entity.HasOne(d => d.IdTipoHabitacionNavigation)
                    .WithMany(p => p.Habitaciones)
                    .HasForeignKey(d => d.IdTipoHabitacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_TIPOH_HABI");
            });

            modelBuilder.Entity<HistoriasClinica>(entity =>
            {
                entity.HasKey(e => e.IdHistoriaClinica)
                    .HasName("PRIMARY");

                entity.ToTable("historias_clinicas");

                entity.HasIndex(e => e.IdPaciente, "FK_ID_PACIENTE_HISCLIN_idx");

                entity.Property(e => e.IdHistoriaClinica).HasColumnName("id_historia_clinica");

                entity.Property(e => e.FechaIngreso).HasColumnName("fecha_ingreso");

                entity.Property(e => e.Historia)
                    .IsRequired()
                    .HasMaxLength(2000)
                    .HasColumnName("historia");

                entity.Property(e => e.IdPaciente).HasColumnName("id_paciente");

                entity.HasOne(d => d.IdPacienteNavigation)
                    .WithMany(p => p.HistoriasClinicas)
                    .HasForeignKey(d => d.IdPaciente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_PACIENTE_HISCLIN");
            });

            modelBuilder.Entity<Lote>(entity =>
            {
                entity.HasKey(e => e.IdLote)
                    .HasName("PRIMARY");

                entity.ToTable("lotes");

                entity.HasIndex(e => e.IdBodega, "FK_ID_BODEGA_LOTES_idx");

                entity.HasIndex(e => e.IdProducto, "FK_ID_PROD_LOTES_idx");

                entity.Property(e => e.IdLote).HasColumnName("id_lote");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(1)
                    .HasColumnName("estado");

                entity.Property(e => e.Exitencia).HasColumnName("exitencia");

                entity.Property(e => e.FechaCaducidad).HasColumnName("fecha_caducidad");

                entity.Property(e => e.FechaIngreso).HasColumnName("fecha_ingreso");

                entity.Property(e => e.IdBodega).HasColumnName("id_bodega");

                entity.Property(e => e.IdProducto).HasColumnName("id_producto");

                entity.Property(e => e.Marca)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("marca");

                entity.Property(e => e.PrecioUnitario).HasColumnName("precio_unitario");

                entity.HasOne(d => d.IdBodegaNavigation)
                    .WithMany(p => p.Lotes)
                    .HasForeignKey(d => d.IdBodega)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_BODEGA_LOTES");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.Lotes)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_PROD_LOTES");
            });

            modelBuilder.Entity<MedicamentosCaso>(entity =>
            {
                entity.HasKey(e => e.IdMedicamentosCaso)
                    .HasName("PRIMARY");

                entity.ToTable("medicamentos_caso");

                entity.HasIndex(e => e.IdProducto, "FK_ID_PRODUCTO_idx");

                entity.HasIndex(e => e.IdUsuario, "FK_ID_USUARIO_idx");

                entity.Property(e => e.IdMedicamentosCaso).HasColumnName("id_medicamentos_caso");

                entity.Property(e => e.Dosis)
                    .HasColumnType("decimal(10,0)")
                    .HasColumnName("dosis");

                entity.Property(e => e.FechaFin).HasColumnName("fecha_fin");

                entity.Property(e => e.FechaInicio).HasColumnName("fecha_inicio");

                entity.Property(e => e.Frecuencia).HasColumnName("frecuencia");

                entity.Property(e => e.IdProducto).HasColumnName("id_producto");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.Observaciones)
                    .HasMaxLength(500)
                    .HasColumnName("observaciones");

                entity.Property(e => e.UnidadMedida)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("unidad_medida");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.MedicamentosCasos)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_PRODUCTO");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.MedicamentosCasos)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_USUARIO");
            });

            modelBuilder.Entity<MedicamentosRecetum>(entity =>
            {
                entity.HasKey(e => e.IdMedicamentosReceta)
                    .HasName("PRIMARY");

                entity.ToTable("medicamentos_receta");

                entity.HasIndex(e => e.IdProducto, "FK_ID_PRODUCTO_MEDS_RECETA_idx");

                entity.HasIndex(e => e.IdReceta, "FK_ID_RECETA_MEDS_RECETA_idx");

                entity.Property(e => e.IdMedicamentosReceta).HasColumnName("id_medicamentos_receta");

                entity.Property(e => e.Dosis).HasColumnName("dosis");

                entity.Property(e => e.Frecuencia).HasColumnName("frecuencia");

                entity.Property(e => e.IdProducto).HasColumnName("id_producto");

                entity.Property(e => e.IdReceta).HasColumnName("id_receta");

                entity.Property(e => e.Observaciones)
                    .HasMaxLength(100)
                    .HasColumnName("observaciones");

                entity.Property(e => e.UnidadMedida)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("unidad_medida");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.MedicamentosReceta)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_PRODUCTO_MEDS_RECETA");

                entity.HasOne(d => d.IdRecetaNavigation)
                    .WithMany(p => p.MedicamentosReceta)
                    .HasForeignKey(d => d.IdReceta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_RECETA_MEDS_RECETA");
            });

            modelBuilder.Entity<Municipio>(entity =>
            {
                entity.HasKey(e => e.IdMunipio)
                    .HasName("PRIMARY");

                entity.ToTable("municipios");

                entity.HasIndex(e => e.IdDepartamento, "FK_ID_DEPTO_MUN_idx");

                entity.Property(e => e.IdMunipio).HasColumnName("id_munipio");

                entity.Property(e => e.IdDepartamento).HasColumnName("id_departamento");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .HasColumnName("nombre");

                entity.HasOne(d => d.IdDepartamentoNavigation)
                    .WithMany(p => p.Municipios)
                    .HasForeignKey(d => d.IdDepartamento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_DEPTO_MUN");
            });

            modelBuilder.Entity<Paciente>(entity =>
            {
                entity.HasKey(e => e.IdPaciente)
                    .HasName("PRIMARY");

                entity.ToTable("pacientes");

                entity.HasIndex(e => e.IdMunicipio, "FK_MUNI_PACIENTES_idx");

                entity.Property(e => e.IdPaciente).HasColumnName("id_paciente");

                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("apellidos");

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("direccion");

                entity.Property(e => e.Dpi)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("dpi");

                entity.Property(e => e.FechaNacimiento).HasColumnName("fecha_nacimiento");

                entity.Property(e => e.Fotografia)
                    .HasMaxLength(500)
                    .HasColumnName("fotografia");

                entity.Property(e => e.IdMunicipio).HasColumnName("id_municipio");

                entity.Property(e => e.Nombres)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("nombres");

                entity.HasOne(d => d.IdMunicipioNavigation)
                    .WithMany(p => p.Pacientes)
                    .HasForeignKey(d => d.IdMunicipio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MUNI_PACIENTES");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.IdProducto)
                    .HasName("PRIMARY");

                entity.ToTable("productos");

                entity.Property(e => e.IdProducto).HasColumnName("id_producto");

                entity.Property(e => e.Imagen)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasColumnName("imagen");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<ProductosFactura>(entity =>
            {
                entity.HasKey(e => e.IdProductoFactura)
                    .HasName("PRIMARY");

                entity.ToTable("productos_factura");

                entity.HasIndex(e => e.IdFactura, "FK_ID_FACT_PROD_FACT_idx");

                entity.HasIndex(e => e.IdLote, "FK_ID_LOTE_PROD_FACT_idx");

                entity.HasIndex(e => e.IdProducto, "FK_ID_PROD_PROD_FACT_idx");

                entity.Property(e => e.IdProductoFactura).HasColumnName("id_producto_factura");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.IdFactura).HasColumnName("id_factura");

                entity.Property(e => e.IdLote).HasColumnName("id_lote");

                entity.Property(e => e.IdProducto).HasColumnName("id_producto");

                entity.Property(e => e.PrecioUnitario).HasColumnName("precio_unitario");

                entity.HasOne(d => d.IdFacturaNavigation)
                    .WithMany(p => p.ProductosFacturas)
                    .HasForeignKey(d => d.IdFactura)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_FACT_PROD_FACT");

                entity.HasOne(d => d.IdLoteNavigation)
                    .WithMany(p => p.ProductosFacturas)
                    .HasForeignKey(d => d.IdLote)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_LOTE_PROD_FACT");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.ProductosFacturas)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_PROD_PROD_FACT");
            });

            modelBuilder.Entity<Receta>(entity =>
            {
                entity.HasKey(e => e.IdReceta)
                    .HasName("PRIMARY");

                entity.ToTable("recetas");

                entity.HasIndex(e => e.IdCita, "FK_ID_CITA_RECETA_idx");

                entity.HasIndex(e => e.IdUsuario, "FK_ID_USUARIO_RECETA_idx");

                entity.Property(e => e.IdReceta).HasColumnName("id_receta");

                entity.Property(e => e.IdCita).HasColumnName("id_cita");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.HasOne(d => d.IdCitaNavigation)
                    .WithMany(p => p.Receta)
                    .HasForeignKey(d => d.IdCita)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_CITA_RECETA");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Receta)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_USUARIO_RECETA");
            });

            modelBuilder.Entity<ResultadoExamene>(entity =>
            {
                entity.HasKey(e => e.IdResultadoExamen)
                    .HasName("PRIMARY");

                entity.ToTable("resultado_examenes");

                entity.HasIndex(e => e.IdExamenCaso, "FK_EXAMEN_CASO_RES_EXAME_idx");

                entity.Property(e => e.IdResultadoExamen).HasColumnName("id_resultado_examen");

                entity.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .HasColumnName("estado")
                    .HasDefaultValueSql("'A'");

                entity.Property(e => e.IdExamenCaso).HasColumnName("id_examen_caso");

                entity.Property(e => e.Observacion)
                    .HasMaxLength(100)
                    .HasColumnName("observacion");

                entity.HasOne(d => d.IdExamenCasoNavigation)
                    .WithMany(p => p.ResultadoExamenes)
                    .HasForeignKey(d => d.IdExamenCaso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EXAMEN_CASO_RES_EXAME");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.IdRol)
                    .HasName("PRIMARY");

                entity.ToTable("roles");

                entity.Property(e => e.IdRol).HasColumnName("id_rol");

                entity.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .HasColumnName("estado")
                    .HasDefaultValueSql("'A'");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<RolesUsuario>(entity =>
            {
                entity.HasKey(e => e.IdRolUsario)
                    .HasName("PRIMARY");

                entity.ToTable("roles_usuario");

                entity.HasIndex(e => e.IdRol, "FK_ROL_ROLES_USR_idx");

                entity.HasIndex(e => e.IdUsuario, "FK_USURIO_ROLES_USR_idx");

                entity.Property(e => e.IdRolUsario).HasColumnName("id_rol_usario");

                entity.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .HasColumnName("estado")
                    .HasDefaultValueSql("'A'");

                entity.Property(e => e.IdRol).HasColumnName("id_rol");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.RolesUsuarios)
                    .HasForeignKey(d => d.IdRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ROL_ROLES_USR");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.RolesUsuarios)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USURIO_ROLES_USR");
            });

            modelBuilder.Entity<Sucursale>(entity =>
            {
                entity.HasKey(e => e.IdSucursal)
                    .HasName("PRIMARY");

                entity.ToTable("sucursales");

                entity.HasIndex(e => e.IdMunicipio, "FK_ID_MUN_SUCUR_idx");

                entity.Property(e => e.IdSucursal).HasColumnName("id_sucursal");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(100)
                    .HasColumnName("direccion");

                entity.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .HasColumnName("estado")
                    .HasDefaultValueSql("'A'");

                entity.Property(e => e.IdMunicipio).HasColumnName("id_municipio");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .HasColumnName("nombre");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(20)
                    .HasColumnName("telefono");

                entity.HasOne(d => d.IdMunicipioNavigation)
                    .WithMany(p => p.Sucursales)
                    .HasForeignKey(d => d.IdMunicipio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_MUN_SUCUR");
            });

            modelBuilder.Entity<TiposHabitacion>(entity =>
            {
                entity.HasKey(e => e.IdTipoHabitacion)
                    .HasName("PRIMARY");

                entity.ToTable("tipos_habitacion");

                entity.Property(e => e.IdTipoHabitacion).HasColumnName("id_tipo_habitacion");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(45)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<TiposUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario)
                    .HasName("PRIMARY");

                entity.ToTable("tipos_usuario");

                entity.Property(e => e.IdTipoUsuario).HasColumnName("id_tipo_usuario");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<TiposVentum>(entity =>
            {
                entity.HasKey(e => e.IdTipoVenta)
                    .HasName("PRIMARY");

                entity.ToTable("tipos_venta");

                entity.Property(e => e.IdTipoVenta).HasColumnName("id_tipo_venta");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PRIMARY");

                entity.ToTable("usuarios");

                entity.HasIndex(e => e.IdTipoUsuario, "FK_TIPO_US_USARIOS_idx");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("apellidos");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(1)
                    .HasColumnName("estado")
                    .HasDefaultValueSql("'A'");

                entity.Property(e => e.FechaNacimiento).HasColumnName("fecha_nacimiento");

                entity.Property(e => e.IdTipoUsuario).HasColumnName("id_tipo_usuario");

                entity.Property(e => e.Nombres)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("nombres");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasColumnName("password");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("username");

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TIPO_US_USARIOS");
            });

            modelBuilder.Entity<Venta>(entity =>
            {
                entity.HasKey(e => e.IdVenta)
                    .HasName("PRIMARY");

                entity.ToTable("ventas");

                entity.HasIndex(e => e.IdCliente, "FK_CLIENTE_VENTA_idx");

                entity.HasIndex(e => e.IdFactura, "FK_FACTURA_VENTA_idx");

                entity.HasIndex(e => e.IdTipoVenta, "FK_TIPO_VENTA_VENTA_idx");

                entity.HasIndex(e => e.UsuarioVenta, "FK_USUARIO_VENTA_idx");

                entity.Property(e => e.IdVenta).HasColumnName("id_venta");

                entity.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .HasColumnName("estado")
                    .HasDefaultValueSql("'A'");

                entity.Property(e => e.FechaVenta).HasColumnName("fecha_venta");

                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");

                entity.Property(e => e.IdFactura).HasColumnName("id_factura");

                entity.Property(e => e.IdTipoVenta).HasColumnName("id_tipo_venta");

                entity.Property(e => e.Total).HasColumnName("total");

                entity.Property(e => e.UsuarioVenta).HasColumnName("usuario_venta");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CLIENTE_VENTA");

                entity.HasOne(d => d.IdFacturaNavigation)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.IdFactura)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FACTURA_VENTA");

                entity.HasOne(d => d.IdTipoVentaNavigation)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.IdTipoVenta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TIPO_VENTA_VENTA");

                entity.HasOne(d => d.UsuarioVentaNavigation)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.UsuarioVenta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USUARIO_VENTA");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
