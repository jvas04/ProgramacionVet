using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinary.Shared.Entities
{
    public class Agenda
    {
        public int Id { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy/mm/dd HH:mm}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "The field {} is mandatory.")]
        public DateTime Date { get; set; }

        public string Remarks { get; set; }

        [Display(Name="Is Available?")]
        public bool IsAvailable { get; set; }

        public Owner Owners { get; set; }

        public Pet Pets { get; set; }


    }
}
