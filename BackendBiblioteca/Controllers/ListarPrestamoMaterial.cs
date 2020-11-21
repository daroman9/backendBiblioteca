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
    public class ListarPrestamoMaterial : ControllerBase
    {
        private readonly ListarPrestamosMaterialRepository _repository;

        public ListarPrestamoMaterial(ListarPrestamosMaterialRepository repository)
        {
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet("{material}")]
        public async Task<ActionResult<IEnumerable<ListarPrestamosMateriales>>> GetData([FromRoute] string material)
        {
            return await _repository.GetDatos(material);
        }
    }
}