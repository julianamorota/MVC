using LocadoraDigitalMVC.IBusiness;
using LocadoraDigitalMVC.IRepository;
using LocadoraDigitalMVC.Entities;
using System.Collections.Generic;

namespace LocadoraDigitalMVC.Business
{
    public class GeneroBusiness : IGeneroBusiness
    {
        private readonly IGeneroRepository generoRepository;
        public GeneroBusiness(IGeneroRepository _generoRepository)
        {
            this.generoRepository = _generoRepository;
        }

        public Genero Get(int id)
        {
            return generoRepository.Get(id);
        }
        public Genero Create(Genero entity)
        {
            return generoRepository.Create(entity);
        }
        public Genero Update(Genero entity)
        {
            return generoRepository.Update(entity);
        }
        public Genero Delete(Genero entity)
        {
            return generoRepository.Delete(entity);
        }
        public IEnumerable<Genero> GetByFilter(string descricao)
        {
            return generoRepository.GetByFilter(x => x.Descricao.Contains(descricao));
        }
        public IEnumerable<Genero> GetAll()
        {
            return generoRepository.GetAll();
        }
    }
}
