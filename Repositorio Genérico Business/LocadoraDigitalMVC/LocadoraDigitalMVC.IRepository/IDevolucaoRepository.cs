using LocadoraDigitalMVC.Entities;
using System.Collections.Generic;
using System;

namespace LocadoraDigitalMVC.IRepository
{
    public interface IDevolucaoRepository
    {
        Devolucao Get(int id);
        Devolucao Create(Devolucao entity);
        IEnumerable<Devolucao> GetByFilter(string nomeCliente, string nomeFilme, DateTime? dtLocacao, DateTime? dtDevolucao);
        IEnumerable<Devolucao> GetAll();
    }
}
