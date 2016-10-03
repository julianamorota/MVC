using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LocadoraDigitalMVC.Entities
{
    public class Filme
    {
        public virtual int Id { get; set; }

        [Display(Name = "Filme")]
        public virtual string Nome { get; set; }

        public virtual int GeneroId { get; set; }
        [Display(Name = "Gênero")]
        [ForeignKey("GeneroId")]
        public virtual Genero Genero { get; set; }

        public virtual bool Status { get; set; }

    }
}
