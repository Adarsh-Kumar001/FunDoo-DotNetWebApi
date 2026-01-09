using FunDooBusiness.Interfaces;
using FunDooModels.DTOs.NoteHistory;
using FunDooRepository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunDooBusiness.Services
{
    public class NoteHistoryService : INoteHistoryService
    {
        private readonly INoteHistoryRepository _repository;

        public NoteHistoryService(INoteHistoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<NoteHistoryResponseDTO>> GetHistoryByNoteAsync(int noteId, int userId)
        {
            var histories = await _repository.GetByNoteIdAsync(noteId, userId);

            return histories.Select(h => new NoteHistoryResponseDTO
            {
                NoteHistoryId = h.NoteHistoryId,
                NoteId = h.NoteId,
                OldTitle = h.OldTitle,
                OldContent = h.OldContent,
                ModifiedAt = h.ModifiedAt
            }).ToList();
        }
    }
}
