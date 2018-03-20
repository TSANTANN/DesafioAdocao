using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core.Model
{
    public class Especie
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string Nome { get; set; }

        public virtual ICollection<Animal> Animal { get; set; }

        public bool IsValid
        {
            get { return Validator.TryValidateObject(this, new ValidationContext(this, null, null), null, true); }
        }

        public bool Update(Especie especie)
        {
            if (this.Id == especie.Id)
            {
                this.Nome = especie.Nome;
             
                return true;
            }
            return false;


        }

    }
}
