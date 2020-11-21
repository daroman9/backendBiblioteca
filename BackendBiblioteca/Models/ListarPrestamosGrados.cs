using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendBiblioteca.Models
{
    public class ListarPrestamosGrados
    {
        public string nombreAlumno { get; set; }
        public string apellidoAlumno { get; set; }
        public string documentoAlumno { get; set; }
        public int idPrestamo { get; set; }
        public int idMaterial { get; set; }
        public string nombreMaterial { get; set; }
        public DateTime fechaInicial { get; set; }
        public DateTime fechaFinal { get; set; }
    }
}
