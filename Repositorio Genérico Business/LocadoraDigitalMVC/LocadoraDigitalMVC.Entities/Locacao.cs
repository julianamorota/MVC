using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LocadoraDigitalMVC.Entities
{
    public class Locacao
    {
        public virtual int Id { get; set; }

        public virtual int ClienteId { get; set; }
        [Display(Name = "Cliente")]
        [ForeignKey("ClienteId")]
        public virtual Cliente Cliente { get; set; }

        public virtual int FilmeId { get; set; }
        [Display(Name = "Filme")]
        [ForeignKey("FilmeId")]
        public virtual Filme Filme { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data locação")]
        public virtual DateTime dtLocacao { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data prevista devolução")]
        public virtual DateTime dtDevolucao { get; set; }

        public virtual bool Devolvido { get; set; }


    }
}
