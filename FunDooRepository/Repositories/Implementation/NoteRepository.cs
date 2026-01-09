using FunDooRepository.DbContextFolder;
using FunDooRepository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FunDooRepository.Repositories.Interfaces;

namespace FunDooRepository.Repositories.Implementation
{
    public class NoteRepository : INoteRepository
    {
        private readonly FunDooNotesDbContext _context;

        public NoteRepository(FunDooNotesDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Note> GetNotesByUser(int userId)
        {
            return _context.Notes
                .Where(n => n.UserId == userId && !n.IsDeleted)
                .ToList();
        }

        public Note GetById(int noteId, int userId)
        {
            return _context.Notes
                .FirstOrDefault(n => n.Id == noteId && n.UserId == userId && !n.IsDeleted);
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

        public void Delete(Note note)
        {
            note.IsDeleted = true;
            _context.SaveChanges();
        }
    }
}
