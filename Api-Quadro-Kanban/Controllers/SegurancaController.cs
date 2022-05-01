using Kanban.Application.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Api_Quadro_Kanban.Controllers
{

    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1")]
    [Authorize()]
    public class SegurancaController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public SegurancaController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("Gerar-Token")]
        public IActionResult GeraToken(LoginDTO login)
        {
            var Login = _configuration.GetSection("Acesso").GetSection("login").Value;
            var Senha = _configuration.GetSection("Acesso").GetSection("senha").Value;

            if (login.Login == Login && login.Senha == Senha)
            {
                var token = GerarJwt();
                return Ok(new
                {
                    Token = token
                }); 
            }
            return Ok(new
            {
                Mensagem = "Login ou Senha inválidos!"
            });
        }

        private string GerarJwt()
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("App-Teste-Pedro-Bruno");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddHours(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
        }


    }
}
