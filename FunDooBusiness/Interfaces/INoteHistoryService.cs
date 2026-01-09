using FunDooModels.DTOs.NoteHistory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunDooBusiness.Interfaces
{
    public interface INoteHistoryService
    {
        Task<List<NoteHistoryResponseDTO>> GetHistoryByNoteAsync(int noteId, int userId);
    }
}
