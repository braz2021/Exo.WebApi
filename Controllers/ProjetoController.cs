using Exo.WebApi.Models;
using Exo.WebApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Exo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjetosController : ControllerBase
    {
        private readonly ProjetoRepository _repository;

        public ProjetosController(ProjetoRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Projeto>> Listar()
        {
            return _repository.Listar();
        }
    }
}
