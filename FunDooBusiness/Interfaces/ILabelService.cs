using FunDooRepository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FunDooModels.DTOs.Labels;

namespace FunDooBusiness.Interfaces
{
    public interface ILabelService
    {
        Task<Label> CreateLabel(int userId, CreateLabelDTO dto);
        Task<IEnumerable<LabelResponseDTO>> GetAllLabels(int userId);
        Task<bool> UpdateLabel(int labelId, int userId, UpdateLabelDTO dto);
        Task<bool> DeleteLabel(int labelId, int userId);

        Task<bool> AddLabelToNote(int noteId, int labelId);
        Task<bool> RemoveLabelFromNote(int noteId, int labelId);
    }
}
