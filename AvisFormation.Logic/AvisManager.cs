using AvisFormation.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvisFormation.Logic
{
    public class AvisManager
    {
        private readonly Data.ApplicationDbContext _context;
        public AvisManager(Data.ApplicationDbContext context)
        {
            _context = context;
        }
        public bool VerifierAvisExiste(int formationId ,string UserId)
        {
            return _context.Avis.Any(a => a.FormationId == formationId && a.UserId == UserId );
        }

        public void AjouterAvis(Avis avis)
        {
            _context.Avis.Add(avis);
            _context.SaveChanges();


        }
    }
}
