using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiCaracterizacion.Models
{
    public class Material_Prestamo
    {
        public int id { get; set; }
        //Clave foranea para relacionar con la tabla Area
        [ForeignKey("Area")]
        public int id_Area { get; set; }
        [JsonIgnore]
        public Area Area { get; set; }
        //Clave foranea para relacionar con la tabla TipoMaterial
        [ForeignKey("Tipo_Material")]
        public int id_TipoMaterial { get; set; }
        [JsonIgnore]
        public Tipo_Material Tipo_Material { get; set; }
        //Clave foranea para relacionar con la tabla Dispositivos
        [ForeignKey("Dispositivos")]
        public int id_Dispositivos { get; set; }
        [JsonIgnore]
        public Dispositivos Dispositivos { get; set; }
        //Clave foranea para relacionar con la tabla Editorial
        [ForeignKey("Editorial")]
        public int id_Editorial { get; set; }
        [JsonIgnore]
        public Editorial Editorial { get; set; }
        public string nombreMaterial { get; set; }
        public int cantidad { get; set; }
        public string observacion { get; set; }
        public string iesbn { get; set; }
        public string grado { get; set; }

    }
}
