using Datos.Config;
using Datos.Entidad;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Contexto
{
    public class GestionTareaContexto : DbContext
    {
        public DbSet<AutenticacionEnt> AutenticacionEnt { get; set; }
        public DbSet<EstadoEnt> EstadoEnt { get; set; }
        public DbSet<PersonaEnt> PersonaEnt { get; set; }
        public DbSet<PrioridadEnt> PrioridadEnt { get; set; }
        public DbSet<TareaEnt> TareaEnt { get; set; }

        public GestionTareaContexto()
        {
        }

        public GestionTareaContexto(DbContextOptions<GestionTareaContexto> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", false, true);
            //IConfigurationRoot root = builder.Build();

            //optionsBuilder.UseSqlServer(root["ConnectionStrings:CityDiscover"]);

            optionsBuilder.UseSqlServer(@"Data Source=LAPTOP-TRD41NTA;Initial Catalog=dbGestionTarea;Integrated Security=true;Trust Server Certificate=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new AutenticacionConfig());
            modelBuilder.ApplyConfiguration(new EstadoConfig());
            modelBuilder.ApplyConfiguration(new PersonaConfig());
            modelBuilder.ApplyConfiguration(new PrioridadConfig());
            modelBuilder.ApplyConfiguration(new TareaConfig());
        }
    }
}
