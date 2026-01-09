using FunDooModels.DTOs.NoteHistory;
using FunDooRepository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunDooRepository.Repositories.Interfaces
{
    public interface INoteHistoryRepository
    {
        Task AddAsync(NoteHistory history);
        Task<List<NoteHistory>> GetByNoteIdAsync(int noteId, int userId);
    }
}
