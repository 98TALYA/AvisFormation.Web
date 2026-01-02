using AvisFormation.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AvisFormation.Web.ViewModels
{
    public class AvisCreateViewModel
    {
        public int FormationId { get; set; }
        [Required(ErrorMessage = "Veuillez saisir un commentaire")]
        public string Commentaire { get; set; }
        [Range(1, 5, ErrorMessage = "La note doit etre entre 1 et 5")]
        public int Note { get; set; }




    }

}

