using FunDooRepository.DbContextFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FunDooRepository.Entities;
using FunDooRepository.Repositories.Interfaces;

namespace FunDooRepository.Repositories.Implementation
{
    public class LabelRepository : ILabelRepository
    {
        private readonly FunDooNotesDbContext _context;

        public LabelRepository(FunDooNotesDbContext context)
        {
            _context = context;
        }

        public Label Add(Label label)
        {
            _context.Labels.Add(label);
            _context.SaveChanges();
            return label;
        }

        public IEnumerable<Label> GetByUserId(long userId)
        {
            return _context.Labels.Where(l => l.UserId == userId).ToList();
        }
    }
}
