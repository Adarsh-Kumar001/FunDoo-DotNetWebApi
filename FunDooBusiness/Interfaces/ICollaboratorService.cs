using FunDooRepository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunDooBusiness.Interfaces
{
    public interface ICollaboratorService
    {
        Collaborator Add(Collaborator collaborator);
        IEnumerable<Collaborator> GetAll(long noteId);
    }
}
