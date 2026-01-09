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
    public class LabelRepository : ILabelRepository
    {
        private readonly FunDooNotesDbContext _context;

        public LabelRepository(FunDooNotesDbContext context)
        {
            _context = context;
        }

        public async Task<Label> CreateAsync(Label label)
        {
            _context.Labels.Add(label);
            await _context.SaveChangesAsync();
            return label;
        }

        public async Task<IEnumerable<Label>> GetAllAsync(int userId)
        {
            return await _context.Labels
                .Where(l => l.UserId == userId)
                .ToListAsync();
        }

        public async Task<Label?> GetByIdAsync(int labelId, int userId)
        {
            return await _context.Labels
                .FirstOrDefaultAsync(l => l.LabelId == labelId && l.UserId == userId);
        }

        public async Task<bool> UpdateAsync(Label label)
        {
            _context.Labels.Update(label);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int labelId, int userId)
        {
            var label = await GetByIdAsync(labelId, userId);
            if (label == null) return false;

            _context.Labels.Remove(label);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> AddLabelToNote(int noteId, int labelId)
        {
            bool exists = await _context.LabelNotes
                .AnyAsync(ln => ln.NoteId == noteId && ln.LabelId == labelId);

            if (exists) return false;

            _context.LabelNotes.Add(new LabelNote
            {
                NoteId = noteId,
                LabelId = labelId
            });

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> RemoveLabelFromNote(int noteId, int labelId)
        {
            var mapping = await _context.LabelNotes
                .FirstOrDefaultAsync(ln => ln.NoteId == noteId && ln.LabelId == labelId);

            if (mapping == null) return false;

            _context.LabelNotes.Remove(mapping);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
