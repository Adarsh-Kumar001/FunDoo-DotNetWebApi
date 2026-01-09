using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FunDooRepository.Entities;

namespace FunDooBusiness.Interfaces
{
    public interface ILabelService
    {
        Label Create(Label label);
        IEnumerable<Label> GetAll(long userId);
    }
}
