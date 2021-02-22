using Data.Entities;
using Data.Interface;
using Domain.Interfaces;

namespace Domain.Services
{
    public class VendaService : ServiceBase<Venda>, IVendaService
    {
        private readonly IRepository<Venda> _repository;

        public VendaService(IRepository<Venda> repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
