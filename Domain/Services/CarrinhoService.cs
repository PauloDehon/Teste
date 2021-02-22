using Data.Entities;
using Data.Interface;
using Domain.Interfaces;

namespace Domain.Services
{
    public class CarrinhoService : ServiceBase<Carrinho>, ICarrinhoService
    {
        private readonly IRepository<Carrinho> _repository;

        public CarrinhoService(IRepository<Carrinho> repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
