using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiCaracterizacion.Models
{
    public class Prestamo
    {
        public int id { get; set; }
        //Clave foranea para relacionar con la tabla Material Prestamo
        [ForeignKey("Material_Prestamo")]
        public int id_MaterialPrestamo { get; set; }
        [JsonIgnore]
        public Material_Prestamo Material_Prestamo { get; set; }
        //Clave foranea para relacionar con la tabla Material Prestamo
        [ForeignKey("Detalle_Usuario")]
        public int id_DetalleUsuario { get; set; }
        [JsonIgnore]
        public Detalle_Usuario Detalle_Usuario { get; set; }
        public DateTime fechaInicial { get; set; }
        public DateTime fechaFinal { get; set; }

    }
}
