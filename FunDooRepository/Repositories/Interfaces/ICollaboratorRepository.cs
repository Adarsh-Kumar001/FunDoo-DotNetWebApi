using FunDooRepository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunDooRepository.Repositories.Interfaces
{
    public interface ICollaboratorRepository
    {
        Collaborator Add(Collaborator collaborator);
        IEnumerable<Collaborator> GetByNoteId(long noteId);
    }
}
