using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FunDooRepository.Entities;

namespace FunDooRepository.Repositories.Interfaces
{
    public interface ILabelRepository
    {
        Task<Label> CreateAsync(Label label);
        Task<IEnumerable<Label>> GetAllAsync(int userId);
        Task<Label?> GetByIdAsync(int labelId, int userId);
        Task<bool> UpdateAsync(Label label);
        Task<bool> DeleteAsync(int labelId, int userId);

        Task<bool> AddLabelToNote(int noteId, int labelId);
        Task<bool> RemoveLabelFromNote(int noteId, int labelId);
    }
}
