using LocadoraDigitalMVC.IBusiness;
using LocadoraDigitalMVC.IRepository;
using LocadoraDigitalMVC.Entities;
using System.Collections.Generic;
using System;

namespace LocadoraDigitalMVC.Business
{
    public class LocacaoBusiness : ILocacaoBusiness
    {
        private readonly ILocacaoRepository locacaoRepository;

        public LocacaoBusiness(ILocacaoRepository _locacaoRepository)
        {
            this.locacaoRepository = _locacaoRepository;
        }

        public Locacao Get(int id)
        {
            return locacaoRepository.Get(id);
        }
        public Locacao Create(Locacao entity)
        {
            return locacaoRepository.Create(entity);
        }
        public Locacao Update(Locacao entity)
        {
            return locacaoRepository.Update(entity);
        }
        public Locacao Devolucao(Locacao entity)
        {
            return locacaoRepository.Devolucao(entity);
        }
        public IEnumerable<Locacao> GetByFilter(string nomeCliente, string nomeFilme, DateTime? dtLocacao, DateTime? dtDevolucao)
        {
            return locacaoRepository.GetByFilter(nomeCliente, nomeFilme, dtLocacao, dtDevolucao);
        }
        public IEnumerable<Locacao> GetAll()
        {
            return locacaoRepository.GetAll();
        }
    }
}
