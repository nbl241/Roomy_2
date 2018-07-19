using Roomy.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Roomy.Areas.BackOffice.Models
{
    public class Category : BaseModel
    {
        [Required(ErrorMessage = "Le champ {0} est obligatoire")]
        [Display(Name = "Libellé")]
        [StringLength(50, MinimumLength = 2,
            ErrorMessage = "Le champ {0} doit contenir entre {2} et {1} caractères")]
        public string Name { get; set; }
    }
}