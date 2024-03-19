using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinary.Shared.Entities
{
    public class Pet
    {
        public int Id { get; set; }

        [Display(Name = "Nombre de la mascota")]
        [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public string Name { get; set; }

        [Display(Name = "Foto mascota")]
      
        public string ImageUrl { get; set; }

        [Display(Name = "Raza mascota")]
        [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public string Race { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy/mm/dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "The field {} is mandatory.")]
        public DateTime Born { get; set; }

        public string Remarks { get; set; }

        public Owner Owner { get; set; }

        public PetType PetType { get; set; }

        public ICollection<History> Histories { get; set; } //Muchos a muchos



    }
}
