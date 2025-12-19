using AvisFormation.Data.Entities;

namespace AvisFormation.Web.ViewModels
{
    public class AccueilViewModel
    {
        public List<FormationViewModel> Formations { get; set; }
        public int NombreFormations { get; set; }
        public int NombreAvis { get; set; }
    }
}
