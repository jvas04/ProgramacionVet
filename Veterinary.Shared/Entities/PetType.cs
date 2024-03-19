﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinary.Shared.Entities
{
    public class PetType
    {
        public int Id { get; set; }

        [Display(Name = "Tipo de mascota")]

        [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters.")]

        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public string Name { get; set; }
    }
}
