using LocadoraDigitalMVC.Entities;
using System.Collections.Generic;

namespace LocadoraDigitalMVC.IBusiness
{
    public interface IClienteBusiness
    {
        Cliente Get(int id);
        Cliente Create(Cliente entity);
        Cliente Update(Cliente entity);
        Cliente Delete(Cliente entity);
        IEnumerable<Cliente> GetByFilter(string nome, string cpf);
        IEnumerable<Cliente> GetAll();
    }
}
