using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiCaracterizacion.Models
{
    public class ApplicationUser: IdentityUser
    {
        [StringLength(250)]
        public string Nombre { get; set; }
        [StringLength(250)]
        public string Apellido { get; set; }
        public int Documento { get; set; }
        public string Password { get; set; }
    }
}
