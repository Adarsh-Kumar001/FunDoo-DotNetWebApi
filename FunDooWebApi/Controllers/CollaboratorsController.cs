using FunDooBusiness.Interfaces;
using FunDooModels.DTOs.Collaborators;
using FunDooRepository.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FunDooWebApi.Controllers
{

    [Authorize]
    [ApiController]
    [Route("api/collaborators")]
    public class CollaboratorController : ControllerBase
    {
        private readonly ICollaboratorService _service;

        public CollaboratorController(ICollaboratorService service)
        {
            _service = service;
        }

        private int GetUserId()
        {
            return int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        }

        // ADD COLLABORATOR
        [HttpPost]
        public async Task<IActionResult> Add(AddCollaboratorDTO dto)
        {
            var result = await _service.AddCollaboratorAsync(GetUserId(), dto);
            return Ok(result);
        }

        // REMOVE COLLABORATOR
        [HttpDelete("{collaboratorId}")]
        public async Task<IActionResult> Remove(int collaboratorId)
        {
            var success = await _service.RemoveCollaboratorAsync(collaboratorId, GetUserId());
            if (!success) return NotFound();

            return Ok("Collaborator removed");
        }

        // GET COLLABORATORS FOR NOTE
        [HttpGet("note/{noteId}")]
        public async Task<IActionResult> GetByNote(int noteId)
        {
            var result = await _service.GetCollaboratorsByNoteAsync(noteId, GetUserId());
            return Ok(result);
        }


    }

}