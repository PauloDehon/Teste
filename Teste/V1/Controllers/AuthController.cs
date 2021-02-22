using AutoMapper;
using Domain.Dtos;
using Domain.Interfaces;
using Infra.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Teste.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Teste.V1.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class AuthController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;

        public AuthController(IUsuarioService serviceUsuario,
                                    IMapper mapper)
        {
            _usuarioService = serviceUsuario;
            _mapper = mapper;
        }

        // GET: api/<ProdutoController>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]PageParams pageParams)
        {
            var produtos = await _usuarioService.AllAsync(pageParams);

            var produtosResultado = _mapper.Map<IEnumerable<ProdutoDto>>(produtos);

            Response.AddPagination(produtos.CurrentPage, produtos.PageSize, produtos.TotalCount, produtos.TotalPages);

            return Ok(produtosResultado);
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public IActionResult Authenticate([FromBody] LoginDto loginDto)
        {
            var usuario = _usuarioService.Get(x => x.Email == loginDto.Email && x.Password == loginDto.Password);
            
            if (usuario == null) return NotFound("Usuário não encontrado");

            var token = TokenService.GenerateToken(usuario);
            usuario.Password = "";
            return Ok(new 
            {
                usuario,
                token
            });
        }

        [HttpGet("anonymous")]
        [AllowAnonymous]
        public string Anonymous() => "Anônimo";

        /// <summary>
        /// Método de autenticação do usuário
        /// </summary>
        /// <returns></returns>
        [HttpGet("authenticated")]
        [Authorize]
        public string Authenticated() => string.Format($"Autenticado - {0}", User.Identity.Name);

        [HttpGet("Verificar")]
        [Authorize(Roles = "admin")]
        public string Verificar() => "produtos";
    }
}
