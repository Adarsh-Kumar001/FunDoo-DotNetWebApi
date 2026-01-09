using FunDooBusiness.Interfaces;
using FunDooRepository.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FunDooWebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/note-history")]
    public class NoteHistoryController : ControllerBase
    {
        private readonly INoteHistoryService _service;

        public NoteHistoryController(INoteHistoryService service)
        {
            _service = service;
        }

        private int GetUserId()
        {
            return int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        }

        // GET HISTORY OF A NOTE
        [HttpGet("{noteId}")]
        public async Task<IActionResult> GetHistory(int noteId)
        {
            var result = await _service.GetHistoryByNoteAsync(noteId, GetUserId());
            return Ok(result);
        }
    }
}
