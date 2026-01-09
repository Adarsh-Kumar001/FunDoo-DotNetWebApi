using FunDooModels.DTOs.Collaborators;
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
        Task<CollaboratorResponseDTO> AddCollaboratorAsync(int ownerUserId, AddCollaboratorDTO dto);
        Task<bool> RemoveCollaboratorAsync(int collaboratorId, int ownerUserId);
        Task<List<CollaboratorResponseDTO>> GetCollaboratorsByNoteAsync(int noteId, int ownerUserId);
    }
}
