using FunDooBusiness.Interfaces;
using FunDooModels.DTOs.Notes;
using FunDooRepository.Entities;
using FunDooRepository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunDooBusiness.Services
{
    public class NoteService  : INoteService
    {
        private readonly INoteRepository _noteRepository;

        public NoteService(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public IEnumerable<Note> GetNotes(int userId)
        {
            return _noteRepository.GetNotesByUser(userId);
        }

        public Note GetNoteById(int noteId, int userId)
        {
            return _noteRepository.GetById(noteId, userId);
        }

        public Note CreateNote(CreateNoteDTO dto, int userId)
        {
            var note = new Note
            {
                Title = dto.Title,
                Description = dto.Description,
                Color = dto.Color,
                UserId = userId
            };

            return _noteRepository.Add(note);
        }

        public bool UpdateNote(int noteId, UpdateNoteDTO dto, int userId)
        {
            var note = _noteRepository.GetById(noteId, userId);
            if (note == null) return false;

            note.Title = dto.Title;
            note.Description = dto.Description;
            note.Color = dto.Color;
            note.UpdatedAt = DateTime.UtcNow;

            _noteRepository.Update(note);
            return true;
        }

        public bool DeleteNote(int noteId, int userId)
        {
            var note = _noteRepository.GetById(noteId, userId);
            if (note == null) return false;

            _noteRepository.Delete(note);
            return true;
        }

        public bool TogglePin(int noteId, int userId)
        {
            var note = _noteRepository.GetById(noteId, userId);
            if (note == null) return false;

            note.IsPinned = !note.IsPinned;
            _noteRepository.Update(note);
            return true;
        }

        public bool ToggleArchive(int noteId, int userId)
        {
            var note = _noteRepository.GetById(noteId, userId);
            if (note == null) return false;

            note.IsArchived = !note.IsArchived;
            _noteRepository.Update(note);
            return true;
        }

    }
}
