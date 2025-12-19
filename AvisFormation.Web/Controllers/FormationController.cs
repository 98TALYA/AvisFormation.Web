using AvisFormation.Data;
using AvisFormation.Logic;
using AvisFormation.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AvisFormation.Web.Controllers
{
    public class FormationController : Controller
    {
       private readonly FormationManager _formationManager;
        public FormationController(FormationManager manager  )
        {
            _formationManager = manager;
        }
        public IActionResult Index()
        {
           var formations = _formationManager.GetAll();
            var formationViewModels = new List<FormationViewModel>();
            foreach (var formation in formations)
            {
                var fvm = new FormationViewModel();
                fvm.Id = formation.Id;
                fvm.Titre = formation.Titre;
                fvm.Description = formation.Description;
                fvm.Lien = formation.Lien;
                fvm.ImageURL = formation.ImageURL;
                fvm.Prix = formation.Prix;
                if (formation.Avis.Count > 0)
                {
                   fvm.MoyenneAvis = formation.Avis.Average(a => a.Note);
                    fvm.MoyenneAvis = Math.Round(fvm.MoyenneAvis, 2);
                    fvm.NombreAvis = formation.Avis.Count;

                }
                else
                {
                    fvm.MoyenneAvis = 0;
                    fvm.NombreAvis = 0;
                }
              
                fvm.EstPopulaire = fvm.MoyenneAvis >= 4.5 && fvm.NombreAvis >= 10;
                formationViewModels.Add(fvm);


            }


            var nombreFormations = formations.Count;
            var nombreAvis = formations.Sum(f => f.Avis.Count);
            var vm = new AccueilViewModel
            {
                Formations = formationViewModels,
                NombreFormations = nombreFormations,
                NombreAvis = nombreAvis

            };

            return View(vm);
        }
    }
}
