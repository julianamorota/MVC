using LocadoraDigitalMVC.Entities;
using System.Collections.Generic;

namespace LocadoraDigitalMVC.IRepository
{
    public interface IGeneroRepository
    {
        Genero Get(int id);
        Genero Create(Genero entity);
        Genero Update(Genero entity);
        Genero Delete(Genero entity);
        IEnumerable<Genero> GetByFilter(string descricao);
        IEnumerable<Genero> GetAll();
    }
}
