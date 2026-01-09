using FunDooBusiness.Interfaces;
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

        public Collaborator Add(Collaborator collaborator)
        {
            return _repository.Add(collaborator);
        }

        public IEnumerable<Collaborator> GetAll(long noteId)
        {
            return _repository.GetByNoteId(noteId);
        }
    }
}
