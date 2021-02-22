using Data.Entities;
using Data.Interface;
using Domain.Interfaces;

namespace Domain.Services
{
    public class EstoqueService : ServiceBase<Estoque>, IEstoqueService
    {
        private readonly IRepository<Estoque> _repository;

        public EstoqueService(IRepository<Estoque> repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
