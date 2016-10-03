using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LocadoraDigitalMVC.Entities
{
    public class Genero
    {
        public virtual int Id { get; set; }

        [Display(Name = "Gênero")]
        public virtual string Descricao { get; set; }

        public virtual ICollection<Filme> Filmes { get; set; }
    }
}
