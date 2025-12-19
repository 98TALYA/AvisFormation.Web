using AvisFormation.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvisFormation.Logic
{
    public class FormationManager
    {
        private readonly Data.ApplicationDbContext _context;
        public FormationManager(Data.ApplicationDbContext context)
        {
            _context = context;
        }
        public List<Formation> GetAll()
        {
            return _context.Formations.Include(f => f.Avis).ToList();
        }
    }
}
