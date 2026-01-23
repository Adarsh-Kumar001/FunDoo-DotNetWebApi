using FunDooBusiness.Interfaces;
using FunDooModels.DTOs.Notes;
using FunDooModels.DTOs.Notes;
using FunDooRepository.Entities;
using FunDooRepository.Repositories.Implementation;
using FunDooRepository.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
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
        private readonly INoteHistoryRepository _noteHistoryRepository;

        public NoteService(
            INoteRepository noteRepository,
            INoteHistoryRepository noteHistoryRepository)
        {
            _noteRepository = noteRepository;
            _noteHistoryRepository = noteHistoryRepository;
        }


        public IEnumerable<NoteResponseDTO> GetNotes(int userId, bool deleted = false)
        {
            var notes = _noteRepository.GetNotesByUser(userId, deleted);

            return notes.Select(n => new NoteResponseDTO
            {
                Id = n.Id,
                Title = n.Title,
                Description = n.Description,
                IsPinned = n.IsPinned,
                IsArchived = n.IsArchived,
                IsDeleted = n.IsDeleted,
                Color = n.Color,
                Labels = n.LabelNotes
                    .Where(ln => ln.Label != null)
                    .Select(ln => new LabelDTO
                    {
                        LabelId = ln.Label.LabelId,
                        LabelName = ln.Label.LabelName
                    })
                    .ToList()
            });
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

            // SAVE OLD DATA FIRST (IMPORTANT)
            var history = new NoteHistory
            {
                NoteId = note.Id,
                OldTitle = note.Title,
                OldContent = note.Description,
                ModifiedAt = DateTime.UtcNow
            };

            _noteHistoryRepository.AddAsync(history).Wait();

            //  UPDATE NOTE
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

            if (!note.IsDeleted)
            {
                // Move to bin
                note.IsDeleted = true;

                _noteRepository.Update(note);
            }
            else
            {
                // Permanent delete
                _noteRepository.HardDelete(note);
            }

            return true;
        }

        public bool RestoreNote(int noteId, int userId)
        {
            var note = _noteRepository.GetById(noteId, userId);
            if (note == null) return false;

            note.IsDeleted = false;
            note.IsArchived = false;
            note.UpdatedAt = DateTime.UtcNow;

            _noteRepository.Update(note);
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
