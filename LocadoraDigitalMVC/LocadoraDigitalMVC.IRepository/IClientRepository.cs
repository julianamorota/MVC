using LocadoraDigitalMVC.Entities;
using System.Collections.Generic;

namespace LocadoraDigitalMVC.IRepository
{
    public interface IClientRepository
    {
        Cliente Get(int id);
        Cliente Create(Cliente entity);
        Cliente Update(Cliente entity);
        Cliente Delete(Cliente entity);
        IEnumerable<Cliente> GetByFilter(string nome, string cpf);
        IEnumerable<Cliente> GetAll();
    }
}
