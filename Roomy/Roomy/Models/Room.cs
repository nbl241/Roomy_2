using Roomy.Areas.BackOffice.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;

namespace Roomy.Models
{
    public class Room : BaseModel
    {
        [Required(ErrorMessage = "Le champ {0} est obligatoire")]
        [StringLength(50)]
        [Display(Name = ("Libellé"))]
        public string Name { get; set; }

        [Required(ErrorMessage = "Le champ {0} est obligatoire")]
        [Range(0, 50)]
        [Display(Name = ("Nombre de place"))]
        public int Capacite { get; set; }

        [Required(ErrorMessage = "Le champ {0} est obligatoire")]
        [DataType(DataType.Currency)]
        [Display(Name = ("Tarif"))]
        public decimal Price { get; set; }

        [Display(Name = ("Description"))]
        [DataType(DataType.MultilineText)]
        [AllowHtml]
        public string Description { get; set; }

        [Required(ErrorMessage = "Le champ {0} est obligatoire")]
        [DataType(DataType.Date)]
        [Display(Name = ("Date de création"))]
        [DisplayFormat(DataFormatString = "{0:dddd dd MMMM yyyy}")]
        public DateTime CreatedAt { get; set; }

        [Display(Name = "Utilisateur/Créateur")]
        public int? UserID { get; set; }

        [ForeignKey("UserID")]
        public User User { get; set; }

        [Display(Name = "Categorie")]
        public int CategoryID { get; set; }

        [ForeignKey("CategoryID")]
        public Category Category { get; set; }

    }
}