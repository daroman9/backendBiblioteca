using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendBiblioteca.DataConsultas;
using BackendBiblioteca.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendBiblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatosPrestamo : ControllerBase
    {
        private readonly DatosPrestamoRepository _repository;

        public DatosPrestamo(DatosPrestamoRepository repository)
        {
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DatosPrestamos>>> GetData()
        {
            return await _repository.GetDatos();
        }
    }
}