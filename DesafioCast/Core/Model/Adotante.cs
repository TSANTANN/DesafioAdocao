using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Model
{
    public class Adotante
    {
        [Key]
        public int Id { get; set; }

        public int PessoaId { get; set; }

        public int AnimalId { get; set; }

        [Required(ErrorMessage = "O campo Data de Adoção é obrigatório.")]
        public string DataAdocao { get; set; }

        public virtual Pessoa Pessoa { get; set; }
        public virtual Animal Animal { get; set; }


        public bool IsValid
        {
            get { return Validator.TryValidateObject(this, new ValidationContext(this, null, null), null, true); }
        }

        public bool Update(Adotante adotante)
        {
            if (this.Id == adotante.Id)
            {
                this.PessoaId = adotante.PessoaId;
                this.AnimalId = adotante.AnimalId;
                this.DataAdocao = adotante.DataAdocao;

                return true;
            }
            return false;


        }

    }
    
  

}
