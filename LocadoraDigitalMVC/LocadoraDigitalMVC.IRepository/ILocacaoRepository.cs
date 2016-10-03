using LocadoraDigitalMVC.Entities;
using System.Collections.Generic;
using System;

namespace LocadoraDigitalMVC.IRepository
{
    public interface ILocacaoRepository
    {
        Locacao Get(int id);
        Locacao Create(Locacao entity);
        Locacao Update(Locacao entity);
        Locacao Devolucao(Locacao entity);
        IEnumerable<Locacao> GetByFilter(string nomeCliente, string nomeFilme, DateTime? dtLocacao, DateTime? dtDevolucao);
        IEnumerable<Locacao> GetAll();
    }
}
