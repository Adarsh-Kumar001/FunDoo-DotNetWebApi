using FunDooRepository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FunDooModels.DTOs.Notes;

namespace FunDooBusiness.Interfaces
{
    public interface INoteService
    {
        IEnumerable<Note> GetNotes(int userId);
        Note GetNoteById(int noteId, int userId);
        Note CreateNote(CreateNoteDTO dto, int userId);
        bool UpdateNote(int noteId, UpdateNoteDTO dto, int userId);
        bool DeleteNote(int noteId, int userId);
        bool TogglePin(int noteId, int userId);
        bool ToggleArchive(int noteId, int userId);
    }
}
