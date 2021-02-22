using AutoMapper;
using Data.Entities;
using Domain.Dtos;
using Domain.Interfaces;
using Infra.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Teste.V1.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;
        private readonly IMapper _mapper;

        public ProdutoController(IProdutoService produtoService,
                                    IMapper mapper)
        {
            _produtoService = produtoService;
            _mapper = mapper;
        }

        // GET: api/<ProdutoController>
        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Get([FromQuery]PageParams pageParams)
        {
            var produtos = await _produtoService.AllAsync(pageParams);

            var produtosResultado = _mapper.Map<IEnumerable<ProdutoDto>>(produtos);

            Response.AddPagination(produtos.CurrentPage, produtos.PageSize, produtos.TotalCount, produtos.TotalPages);

            return Ok(produtosResultado);
        }

        // GET api/<ProdutoController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_produtoService.Get(x => x.Id == id));
        }

        // POST api/<ProdutoController>
        [HttpPost]
        public async Task<IActionResult> Post(Produto produto)
        {
            var resultado = await _produtoService.AddAsync(produto);
            return Ok(resultado);
        }

        // PUT api/<ProdutoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProdutoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
