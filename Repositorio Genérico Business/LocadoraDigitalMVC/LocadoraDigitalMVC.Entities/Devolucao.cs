using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LocadoraDigitalMVC.Entities
{
    public class Devolucao
    {
        public virtual int Id { get; set; }

        public virtual int LocacaoId { get; set; }
        [Display(Name = "Locacao")]
        [ForeignKey("LocacaoId")]
        public virtual Locacao Locacao { get; set; }

        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
 
        [Display(Name = "Data devolução")]
        public virtual DateTime dtDev { get; set; }

        public virtual string Multa { get; set; }


    }
}
