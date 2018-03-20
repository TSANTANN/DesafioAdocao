using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core.Model
{
    public class Pessoa
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo Cep é obrigatório.")]
        public string Cep {get;set;}

        [Required(ErrorMessage = "O campo Telefone é obrigatório.")]
        public string Telefone { get; set; }


        public virtual ICollection<Adotante> Adotante { get; set; }


        public bool IsValid
        {
            get { return Validator.TryValidateObject(this, new ValidationContext(this, null, null), null, true); }
        }

        public bool Update(Pessoa pessoa)
        {
            if (this.Id == pessoa.Id)
            {
                this.Nome = pessoa.Nome;
                this.Cep = pessoa.Cep;
                this.Telefone = pessoa.Telefone;

                return true;
            }
            return false;


        }


    }
}
