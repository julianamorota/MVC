using LocadoraDigitalMVC.IBusiness;
using LocadoraDigitalMVC.IRepository;
using LocadoraDigitalMVC.Entities;
using System.Collections.Generic;
using System;

namespace LocadoraDigitalMVC.Business
{
    public class DevolucaoBusiness : IDevolucaoBusiness
    {
        private readonly IDevolucaoRepository DevolucaoRepository;

        public DevolucaoBusiness(IDevolucaoRepository _DevolucaoRepository)
        {
            this.DevolucaoRepository = _DevolucaoRepository;
        }

        public Devolucao Get(int id)
        {
            return DevolucaoRepository.Get(id);
        }
        public Devolucao Create(Devolucao entity)
        {
            return DevolucaoRepository.Create(entity);
        }
        public IEnumerable<Devolucao> GetByFilter(string nomeCliente, string nomeFilme, DateTime? dtLocacao, DateTime? dtDevolucao)
        {
            return DevolucaoRepository.GetByFilter(nomeCliente, nomeFilme, dtLocacao, dtDevolucao);
        }
        public IEnumerable<Devolucao> GetAll()
        {
            return DevolucaoRepository.GetAll();
        }
    }
}
