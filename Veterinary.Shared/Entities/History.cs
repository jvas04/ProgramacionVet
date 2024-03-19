using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinary.Shared.Entities
{
    public class History
    {
        public int Id { get; set; }

        [Display(Name = "Descripción")]
        [MaxLength(100, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public string Description { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy/mm/dd HH:mm}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "The field {} is mandatory.")]
        public DateTime Date { get; set; }

        [Display(Name = "Comentarios/Observaciones")]
        [MaxLength(100, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public string Remarks { get; set; }

        public DateTime DateLocal => Date.ToLocalTime();

        public ServiceType ServiceType { get; set; }

        public Pet Pet {  get; set; }
    }
}
