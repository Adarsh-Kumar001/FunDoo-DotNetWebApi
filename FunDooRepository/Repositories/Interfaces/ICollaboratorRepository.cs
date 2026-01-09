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
        Task<Collaborator> AddAsync(Collaborator collaborator);
        Task<bool> RemoveAsync(int collaboratorId, int ownerUserId);
        Task<List<Collaborator>> GetByNoteIdAsync(int noteId, int ownerUserId);
    }
}
