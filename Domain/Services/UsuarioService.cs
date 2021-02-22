using Data.Entities;
using Data.Interface;
using Domain.Interfaces;

namespace Domain.Services
{
    public class UsuarioService : ServiceBase<Usuario>, IUsuarioService
    {
        private readonly IRepository<Usuario> _repository;

        public UsuarioService(IRepository<Usuario> repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
