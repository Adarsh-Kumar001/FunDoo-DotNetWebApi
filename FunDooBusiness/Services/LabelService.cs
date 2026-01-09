using FunDooBusiness.Interfaces;
using FunDooRepository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FunDooRepository.Entities;


namespace FunDooBusiness.Services
{
    public class LabelService : ILabelService
    {
        private readonly ILabelRepository _labelRepository;

        public LabelService(ILabelRepository labelRepository)
        {
            _labelRepository = labelRepository;
        }

        public Label Create(Label label)
        {
            return _labelRepository.Add(label);
        }

        public IEnumerable<Label> GetAll(long userId)
        {
            return _labelRepository.GetByUserId(userId);
        }
    }
}
