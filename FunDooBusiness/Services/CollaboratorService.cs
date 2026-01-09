using FunDooBusiness.Interfaces;
using FunDooModels.DTOs.Collaborators;
using FunDooRepository.Entities;
using FunDooRepository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunDooBusiness.Services
{
    public class CollaboratorService : ICollaboratorService
    {
        private readonly ICollaboratorRepository _repository;

        public CollaboratorService(ICollaboratorRepository repository)
        {
            _repository = repository;
        }

        public async Task<CollaboratorResponseDTO> AddCollaboratorAsync(int ownerUserId, AddCollaboratorDTO dto)
        {
            var collaborator = new Collaborator
            {
                CollaboratorEmail = dto.CollaboratorEmail,
                NoteId = dto.NoteId,
                OwnerUserId = ownerUserId
            };

            var result = await _repository.AddAsync(collaborator);

            return new CollaboratorResponseDTO
            {
                CollaboratorId = result.CollaboratorId,
                CollaboratorEmail = result.CollaboratorEmail,
                NoteId = result.NoteId
            };
        }

        public async Task<bool> RemoveCollaboratorAsync(int collaboratorId, int ownerUserId)
        {
            return await _repository.RemoveAsync(collaboratorId, ownerUserId);
        }

        public async Task<List<CollaboratorResponseDTO>> GetCollaboratorsByNoteAsync(int noteId, int ownerUserId)
        {
            var collaborators = await _repository.GetByNoteIdAsync(noteId, ownerUserId);

            return collaborators.Select(c => new CollaboratorResponseDTO
            {
                CollaboratorId = c.CollaboratorId,
                CollaboratorEmail = c.CollaboratorEmail,
                NoteId = c.NoteId
            }).ToList();
        }
    }
}
