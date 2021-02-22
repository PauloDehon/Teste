using Data.Entities;
using Data.Interface;
using Domain.Interfaces;

namespace Domain.Services
{
    public class ProdutoService : ServiceBase<Produto>, IProdutoService
    {
        private readonly IRepository<Produto> _repository;

        public ProdutoService(IRepository<Produto> repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
