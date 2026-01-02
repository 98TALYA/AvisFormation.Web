using AvisFormation.Data.Entities;
using AvisFormation.Logic;
using AvisFormation.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AvisFormation.Web.Controllers
{
    public class AvisController : Controller
    {
        private readonly AvisManager _avisManager;
        public AvisController(AvisManager manager)
        {
            _avisManager = manager;
        }
        [Authorize]
        [HttpGet]
        public IActionResult AjouterUnAvis(int id)
        {
            var vm = new AvisCreateViewModel();
            vm.FormationId = id;
            return View(vm);
        }
        [HttpPost]
        public IActionResult AjouterUnAvis(AvisCreateViewModel vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            bool deja = _avisManager.VerifierAvisExiste(vm.FormationId, userId);
            if (deja)
            {
                ModelState.AddModelError(string.Empty, "Vous avez deja laissé un avis pour cette formation");
                return View(vm);
            }
            var avis = new Avis();
            avis.FormationId = vm.FormationId;
            avis.Auteur = User.Identity.Name;
            avis.Commentaire = vm.Commentaire;
            avis.Note = vm.Note;
            avis.DateAvis = DateTime.Now;
            avis.UserId = userId;
            _avisManager.AjouterAvis(avis);
            
            return RedirectToAction("DetailsFormation", "Formation", new {id=vm.FormationId});
        }
    }
}
