using Kanban.Application.DTOs;
using Kanban.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Api_Quadro_Kanban.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1")]
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
        [Route("Obter-Quadros")]
        public IActionResult ObterQuadros()
        {
            return Ok( _appQuadro.ObterListaDeQuadros() );
        }

        [HttpPost]
        [Route("Adicionar-Quadro")]
        [AllowAnonymous]
        public IActionResult AdicionarQuadro([FromBody] QuadroDTO model)
        {
            return Ok(_appQuadro.IncluirQuadro(model));
        }

        [HttpPut]
        [Route("Alterar-Quadro")]
        [AllowAnonymous]
        public IActionResult AlterarQuadro(Guid id, [FromBody] QuadroDTO model)
        {
            var quadro = _appQuadro.ObterPorId(id);
            if(quadro == null)
            {
                return NotFound($"{id} não encontrado");
            }

            model.Id = id;
            return Ok(_appQuadro.AlterarQuadro(model));
        }

        [HttpDelete]
        [Route("Excluir-Quadro")]
        [AllowAnonymous]
        public IActionResult ExcluirQuadro(Guid id)
        {
            var quadro = _appQuadro.ObterPorId(id);
            if (quadro == null)
            {
                return NotFound($"{id} não encontrado");
            }
            return Ok(_appQuadro.ExcluirQuadro(id));
        }


    }
}
