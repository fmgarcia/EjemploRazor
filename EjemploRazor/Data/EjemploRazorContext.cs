#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using EjemploRazor.Models;

namespace EjemploRazor.Data
{
    public class EjemploRazorContext : DbContext
    {
        public EjemploRazorContext(DbContextOptions<EjemploRazorContext> options)
            : base(options)
        {
            // Sql Server
            //string cadenaConexion = "Server=localhost;Charset=utf8;Database=productos;User=root;Password=;";
            //options.UseMySql(cadenaConexion, ServerVersion.AutoDetect(cadenaConexion));
        }

        public EjemploRazorContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Sql Server (por defecto)
            //string cadenaConexion = "Server=(localdb)\\mssqllocaldb;Database=EjemploRazorContext-b27ff19e-9082-48ef-8493-8fe8a54e8853;Trusted_Connection=True;MultipleActiveResultSets=true";
            //optionsBuilder.UseSqlServer(cadenaConexion);
            // MySql
            string cadenaConexion = "Server=localhost;Charset=utf8;Database=guildwar2;User=root;Password=;";
            optionsBuilder.UseMySql(cadenaConexion, ServerVersion.AutoDetect(cadenaConexion));

        }

        public DbSet<EjemploRazor.Models.Movie> Movie { get; set; }
        public DbSet<EjemploRazor.Models.Especializacion> Especializacion { get; set; }
    }
}
