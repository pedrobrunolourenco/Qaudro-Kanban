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
    public class QuadroController : Controller
    {
        private readonly IAppQuadro _appQuadro;
        public QuadroController(IAppQuadro appQuadro)
        {
            _appQuadro = appQuadro;
        }

        [HttpGet]
        [AllowAnonymous]
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
        [AllowAnonymous]
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
        [AllowAnonymous]
        [FilterLogAlteracaoExclusao("AlterarQuadro")]
        public IActionResult AlterarQuadro(Guid id, [FromBody] QuadroDTO model)
        {
            try
            {
                model.Id = id;
                return Ok(_appQuadro.AlterarQuadro(model));
            }
            catch
            {
                return NotFound($"{id} não encontrado");
            }
        }

        [HttpDelete]
        [Route("Remover")]
        [FilterLogAlteracaoExclusao("RemoverQuadro")]
        [AllowAnonymous]
        public IActionResult ExcluirQuadro(Guid id)
        {
            try
            {
                return Ok(_appQuadro.ExcluirQuadro(id));
            }
            catch
            {
                return NotFound($"{id} não encontrado");
            }
        }


    }
}
