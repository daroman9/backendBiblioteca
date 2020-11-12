using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace WebApiCaracterizacion.Models
{
    public class ApplicationDbContext: IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
     
        public DbSet<Area> Area { get; set; }
        public DbSet<Dispositivos> Dispositivos { get; set; }
        public DbSet<Tipo_Material> Tipo_Material { get; set; }
        public DbSet<Material_Prestamo> Material_Prestamos { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<Editorial> Editorial { get; set; }
        public DbSet<Detalle_Usuario> Detalle_Usuario { get; set; }
        public DbSet<Prestamo> Prestamo { get; set; }


    }
}
