using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendBiblioteca.Models
{
    public class DatosPrestamos
    {
        public int id { get; set; }
        public int idMaterial { get; set; }
        public string nombreMaterial { get; set; }
        public int idUsuario { get; set; }
        public string nombreUsuario { get; set; }
        public string apellidoUsuario { get; set; }
        public DateTime fechaInicial { get; set; }
        public DateTime fechaFinal { get; set; }
    }
}
