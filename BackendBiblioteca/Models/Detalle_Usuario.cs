using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiCaracterizacion.Models
{
    public class Detalle_Usuario
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string documento { get; set; }
        public string grado { get; set; }
        public string nombreAcudiente { get; set; }
        public string apellidoAcudiente { get; set; }
        public string telefonoAcudiente { get; set; }
        public string autorizacion { get; set; }
        public string activo { get; set; }
    }
}
