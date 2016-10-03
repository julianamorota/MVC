using LocadoraDigitalMVC.Entities;
using System.Collections.Generic;

namespace LocadoraDigitalMVC.IRepository
{
    public interface IFilmeRepository
    {
        Filme Get(int id);
        Filme Create(Filme entity);
        Filme Update(Filme entity);
        Filme Delete(Filme entity);
        IEnumerable<Filme> GetByFilter(string nomeFilme, string nomeGenero, string status);
        IEnumerable<Filme> GetAll();
    }
}
