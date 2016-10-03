
using System.ComponentModel.DataAnnotations;
namespace LocadoraDigitalMVC.Entities
{
    public class Cliente
    {
        public virtual int Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Cpf { get; set; }
        public virtual string Telefone { get; set; }

        [Display(Name = "Endereço")]
        public virtual string Endereco { get; set; }
    }
}
