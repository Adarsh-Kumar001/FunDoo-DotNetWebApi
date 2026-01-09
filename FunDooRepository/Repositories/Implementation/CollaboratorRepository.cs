using FunDooRepository.DbContextFolder;
using FunDooRepository.Entities;
using FunDooRepository.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
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

        public async Task<Collaborator> AddAsync(Collaborator collaborator)
        {
            _context.Collaborators.Add(collaborator);
            await _context.SaveChangesAsync();
            return collaborator;
        }

        public async Task<bool> RemoveAsync(int collaboratorId, int ownerUserId)
        {
            var collaborator = await _context.Collaborators
                .Include(c => c.Note)
                .FirstOrDefaultAsync(c =>
                    c.CollaboratorId == collaboratorId &&
                    c.OwnerUserId == ownerUserId);

            if (collaborator == null) return false;

            _context.Collaborators.Remove(collaborator);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Collaborator>> GetByNoteIdAsync(int noteId, int ownerUserId)
        {
            return await _context.Collaborators
                .Where(c => c.NoteId == noteId && c.OwnerUserId == ownerUserId)
                .ToListAsync();
        }
    }
}
