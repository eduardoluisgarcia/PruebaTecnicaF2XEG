using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaTecnicaF2X.Models;

namespace PruebaTecnicaF2X.DBContexts
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext()
        {

        }
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> opciones) : base(opciones)
        {

        }

        public DbSet<RecaudosEntity> Recaudos { get; set; }
        public DbSet<ConteoVehiculosEntity> ConteoVehiculos { get; set; }
        public DbSet<RecaudoVehiculosEntity> RecaudoVehiculos { get; set; }
        public DbSet<ReporteEntity> Reporte { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RecaudosEntity>().HasNoKey().ToView("consultarecaudos");
        }
    }
}
