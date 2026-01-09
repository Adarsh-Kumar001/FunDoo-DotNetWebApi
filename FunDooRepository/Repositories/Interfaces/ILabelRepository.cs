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
        Label Add(Label label);
        IEnumerable<Label> GetByUserId(long userId);
    }
}
