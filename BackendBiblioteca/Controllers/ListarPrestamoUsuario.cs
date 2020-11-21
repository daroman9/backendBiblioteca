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
    public class ListarPrestamoUsuario : ControllerBase
    {
        private readonly ListarPrestamoUsuarioRepository _repository;

        public ListarPrestamoUsuario(ListarPrestamoUsuarioRepository repository)
        {
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet("{documento}")]
        public async Task<ActionResult<IEnumerable<ListarPrestamoUsuarios>>> GetData([FromRoute] string documento)
        {
            return await _repository.GetDatos(documento);
        }
    }
}