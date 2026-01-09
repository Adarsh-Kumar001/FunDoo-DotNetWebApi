using FunDooRepository.DbContextFolder;
using FunDooRepository.Entities;
using FunDooRepository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunDooRepository.Repositories.Implementation
{
    public class CollaboratorRepository : ICollaboratorRepository
    {
        private readonly FunDooNotesDbContext _context;

        public CollaboratorRepository(FunDooNotesDbContext context)
        {
            _context = context;
        }

        public Collaborator Add(Collaborator collaborator)
        {
            _context.Collaborators.Add(collaborator);
            _context.SaveChanges();
            return collaborator;
        }

        public IEnumerable<Collaborator> GetByNoteId(long noteId)
        {
            return _context.Collaborators.Where(c => c.NoteId == noteId).ToList();
        }
    }
}
