using LocadoraDigitalMVC.IBusiness;
using LocadoraDigitalMVC.IRepository;
using LocadoraDigitalMVC.Entities;
using System.Collections.Generic;

namespace LocadoraDigitalMVC.Business
{
    public class ClienteBusiness : IClienteBusiness
    {
        private readonly IClientRepository ClienteRepository;

        public ClienteBusiness(IClientRepository _ClienteRepository)
        {
            this.ClienteRepository = _ClienteRepository;
        }

        public Cliente Get(int id)
        {
            return ClienteRepository.Get(id);
        }
        public Cliente Create(Cliente entity)
        {
            return ClienteRepository.Create(entity);
        }
        public Cliente Update(Cliente entity)
        {
            return ClienteRepository.Update(entity);
        }
        public Cliente Delete(Cliente entity)
        {
            return ClienteRepository.Delete(entity);
        }
        public IEnumerable<Cliente> GetByFilter(string nome, string cpf)
        {
            return ClienteRepository.GetByFilter(nome, cpf);
        }
        public IEnumerable<Cliente> GetAll()
        {
            return ClienteRepository.GetAll();
        }



    }
}
