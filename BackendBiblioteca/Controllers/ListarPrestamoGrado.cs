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
    public class ListarPrestamoGrado : ControllerBase
    {
        private readonly ListarPrestamoGradosRepository _repository;

        public ListarPrestamoGrado(ListarPrestamoGradosRepository repository)
        {
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet("{grado}")]
        public async Task<ActionResult<IEnumerable<ListarPrestamosGrados>>> GetData([FromRoute] string grado)
        {
            return await _repository.GetDatos(grado);
        }
    }
}