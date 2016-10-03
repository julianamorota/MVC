using LocadoraDigitalMVC.IBusiness;
using LocadoraDigitalMVC.IRepository;
using LocadoraDigitalMVC.Entities;
using System.Collections.Generic;

namespace LocadoraDigitalMVC.Business
{
    public class FilmeBusiness : IFilmeBusiness
    {
        private readonly IFilmeRepository filmeRepository;

        public FilmeBusiness(IFilmeRepository _filmeRepository)
        {
            this.filmeRepository = _filmeRepository;
        }

        public Filme Get(int id)
        {
            return filmeRepository.Get(id);
        }
        public Filme Create(Filme entity)
        {
            return filmeRepository.Create(entity);
        }
        public Filme Update(Filme entity)
        {
            return filmeRepository.Update(entity);
        }
        public Filme Delete(Filme entity)
        {
            return filmeRepository.Delete(entity);
        }
        public IEnumerable<Filme> GetByFilter(string nomeFilme, string nomeGenero, string status)
        {
            return filmeRepository.GetByFilter(nomeFilme, nomeGenero, status);
        }
        public IEnumerable<Filme> GetAll()
        {
            return filmeRepository.GetAll();
        }
    }
}
