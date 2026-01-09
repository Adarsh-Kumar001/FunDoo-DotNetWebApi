using FunDooBusiness.Interfaces;
using FunDooRepository.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FunDooWebApi.Controllers
{
    [ApiController]
    [Route("api/collaborators")]
    public class CollaboratorsController : ControllerBase
    {
        private readonly ICollaboratorService _service;

        public CollaboratorsController(ICollaboratorService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Add(Collaborator collaborator)
        {
            return Ok(_service.Add(collaborator));
        }

        [HttpGet("{noteId}")]
        public IActionResult GetAll(long noteId)
        {
            return Ok(_service.GetAll(noteId));
        }

       
    }

}