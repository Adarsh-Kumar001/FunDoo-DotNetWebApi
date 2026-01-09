using FunDooRepository.DbContextFolder;
using FunDooRepository.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FunDooRepository.Repositories.Interfaces;

namespace FunDooRepository.Repositories.Implementation
{
    public class NoteHistoryRepository : INoteHistoryRepository
    {
        private readonly FunDooNotesDbContext _context;

        public NoteHistoryRepository(FunDooNotesDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(NoteHistory history)
        {
            _context.NotesHistory.Add(history);
            await _context.SaveChangesAsync();
        }

        public async Task<List<NoteHistory>> GetByNoteIdAsync(int noteId, int userId)
        {
            return await _context.NotesHistory
                .Include(h => h.Note)
                .Where(h => h.NoteId == noteId && h.Note.UserId == userId)
                .OrderByDescending(h => h.ModifiedAt)
                .ToListAsync();
        }
    }
}
