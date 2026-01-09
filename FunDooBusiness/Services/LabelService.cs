using FunDooBusiness.Interfaces;
using FunDooModels.DTOs.Labels;
using FunDooRepository.Entities;
using FunDooRepository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FunDooBusiness.Services
{
    public class LabelService : ILabelService
    {
        private readonly ILabelRepository _labelRepository;

        public LabelService(ILabelRepository labelRepository)
        {
            _labelRepository = labelRepository;
        }

        public async Task<Label> CreateLabel(int userId, CreateLabelDTO dto)
        {
            var label = new Label
            {
                LabelName = dto.LabelName,
                UserId = userId
            };

            return await _labelRepository.CreateAsync(label);
        }

        public async Task<IEnumerable<Label>> GetAllLabels(int userId)
        {
            return await _labelRepository.GetAllAsync(userId);
        }

        public async Task<bool> UpdateLabel(int labelId, int userId, UpdateLabelDTO dto)
        {
            var label = await _labelRepository.GetByIdAsync(labelId, userId);
            if (label == null) return false;

            label.LabelName = dto.LabelName;
            return await _labelRepository.UpdateAsync(label);
        }

        public async Task<bool> DeleteLabel(int labelId, int userId)
        {
            return await _labelRepository.DeleteAsync(labelId, userId);
        }

        public async Task<bool> AddLabelToNote(int noteId, int labelId)
        {
            return await _labelRepository.AddLabelToNote(noteId, labelId);
        }

        public async Task<bool> RemoveLabelFromNote(int noteId, int labelId)
        {
            return await _labelRepository.RemoveLabelFromNote(noteId, labelId);
        }
    }
}
