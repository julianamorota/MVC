using LocadoraDigitalMVC.Entities;
using System;
using System.Collections.Generic;

namespace LocadoraDigitalMVC.IBusiness
{
    public interface ILocacaoBusiness
    {
        Locacao Get(int id);
        Locacao Create(Locacao entity);
        Locacao Update(Locacao entity);
        Locacao Devolucao(Locacao entity);
        IEnumerable<Locacao> GetByFilter(string nomeCliente, string nomeFilme, DateTime? dtLocacao, DateTime? dtDevolucao);
        IEnumerable<Locacao> GetAll();
    }
}
