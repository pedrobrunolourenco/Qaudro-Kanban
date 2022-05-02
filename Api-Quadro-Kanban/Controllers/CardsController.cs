using Kanban.Application.DTOs;
using Kanban.Application.Interfaces;
using Kanban.Infra.CrossCutting.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Api_Quadro_Kanban.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1")]
    [Produces("application/json")]
    [Authorize()]
    public class CardsController : Controller
    {
        private readonly IAppQuadro _appQuadro;
        public CardsController(IAppQuadro appQuadro)
        {
            _appQuadro = appQuadro;
        }

        [HttpGet]
        [Route("Listar")]
        public IActionResult ObterQuadros()
        {
            try
            {
                return Ok(_appQuadro.ObterListaDeQuadros());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("Adicionar")]
        public IActionResult AdicionarQuadro([FromBody] QuadroDTO model)
        {
            try
            {
                return Ok(_appQuadro.IncluirQuadro(model));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("Alterar")]
        [FilterLogAlteracaoExclusao("Alterar")]
        public IActionResult AlterarQuadro(Guid id, [FromBody] QuadroDTO model)
        {
            var quadro = _appQuadro.ObterPorId(id);
            if (quadro == null)
            {
                return NotFound();
            }

            try
            {
                model.Id = id;
                return Ok(_appQuadro.AlterarQuadro(model));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("Remover")]
        [FilterLogAlteracaoExclusao("Remover")]
        public IActionResult ExcluirQuadro(Guid id)
        {
            var quadro = _appQuadro.ObterPorId(id);
            if(quadro == null)
            {
                return NotFound(); ;
            }

            try
            {
                return Ok(_appQuadro.ExcluirQuadro(id));
            }
            catch
            {
                return BadRequest();
            }
        }


    }
}
