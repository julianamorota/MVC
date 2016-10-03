using LocadoraDigitalMVC.Entities;
using System;
using System.Collections.Generic;

namespace LocadoraDigitalMVC.IBusiness
{
    public interface IDevolucaoBusiness
    {
        Devolucao Get(int id);
        Devolucao Create(Devolucao entity);
        IEnumerable<Devolucao> GetByFilter(string nomeCliente, string nomeFilme, DateTime? dtLocacao, DateTime? dtDevolucao);
        IEnumerable<Devolucao> GetAll();
    }
}
