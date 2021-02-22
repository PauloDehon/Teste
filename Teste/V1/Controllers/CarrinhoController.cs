using AutoMapper;
using Data.Entities;
using Domain.Dtos;
using Domain.Interfaces;
using Infra.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Teste.V1.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class CarrinhoController : ControllerBase
    {
        private readonly ICarrinhoService _service;
        private readonly IMapper _mapper;

        public CarrinhoController(ICarrinhoService service,
                                    IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET: api/<ProdutoController>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]PageParams pageParams)
        {
            var produtos = await _service.AllAsync(pageParams);

            var produtosResultado = _mapper.Map<IEnumerable<ProdutoDto>>(produtos);

            Response.AddPagination(produtos.CurrentPage, produtos.PageSize, produtos.TotalCount, produtos.TotalPages);

            return Ok(produtosResultado);
        }

        // GET api/<ProdutoController>/5
        [HttpGet("{id}")]
        public IActionResult GetVenda(int id)
        {
            return Ok(_service.Get(x => x.VendaId == id));
        }

        // POST api/<ProdutoController>
        [HttpPost]
        public async Task<IActionResult> Post(CarrinhoDto carrinhoDto)
        {
            var carrinho = _mapper.Map<Carrinho>(carrinhoDto);
            var vendaResultado = await _service.AddAsync(carrinho);

            return Ok(vendaResultado);
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
