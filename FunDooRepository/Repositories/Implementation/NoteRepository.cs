using FunDooRepository.DbContextFolder;
using FunDooRepository.Entities;
using FunDooRepository.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FunDooRepository.Repositories.Implementation
{
    public class NoteRepository : INoteRepository
    {
        private readonly FunDooNotesDbContext _context;

        public NoteRepository(FunDooNotesDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Note> GetNotesByUser(int userId, bool isDeleted)
        {
            return _context.Notes
           .Where(n => n.UserId == userId && n.IsDeleted == isDeleted)
           .Include(n => n.LabelNotes)
           .ThenInclude(ln => ln.Label)
           .ToList();
        }

        // Get note even if deleted (IMPORTANT for restore / hard delete)
        public Note GetById(int noteId, int userId)
        {
            return _context.Notes
                .FirstOrDefault(n => n.Id == noteId && n.UserId == userId);
        }

        public Note Add(Note note)
        {
            _context.Notes.Add(note);
            _context.SaveChanges();
            return note;
        }

        public void Update(Note note)
        {
            _context.Notes.Update(note);
            _context.SaveChanges();
        }

        // Permanent delete ONLY
        public void HardDelete(Note note)
        {
            _context.Notes.Remove(note);
            _context.SaveChanges();
        }
    }
}
