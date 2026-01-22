using FunDooBusiness.Interfaces;
using FunDooModels.DTOs.Notes;
using FunDooRepository.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FunDooWebApi.Controllers
{

    [Authorize]
    [ApiController]
    [Route("api/notes")]
    public class NotesController : ControllerBase
    {
        private readonly INoteService _noteService;

        public NotesController(INoteService noteService)
        {
            _noteService = noteService;
        }

        private int GetUserId()
        {
            return int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
        }



        [HttpGet]
        public IActionResult GetNotes([FromQuery] bool deleted = false)
        {
            var notes = _noteService.GetNotes(GetUserId(), deleted);
            return Ok(notes);
        }


        [HttpGet("{id}")]
        public IActionResult GetNote(int id)
        {
            var note = _noteService.GetNoteById(id, GetUserId());
            if (note == null) return NotFound();
            return Ok(note);
        }

        [HttpPost]
        public IActionResult Create(CreateNoteDTO dto)
        {
            return Ok(_noteService.CreateNote(dto, GetUserId()));
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateNoteDTO dto)
        {
            if (!_noteService.UpdateNote(id, dto, GetUserId()))
                return NotFound();

            return Ok(new { message = "Note Updated" });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!_noteService.DeleteNote(id, GetUserId()))
                return NotFound();

            return Ok(new { message = "Note deleted" });
        }

        [HttpPatch("{id}/restore")]
        public IActionResult Restore(int id)
        {
            if (!_noteService.RestoreNote(id, GetUserId()))
                return NotFound();

            return Ok(new { message = "Note Restored" });
        }


        [HttpPatch("{id}/pin")]
        public IActionResult TogglePin(int id)
        {
            if (!_noteService.TogglePin(id, GetUserId()))
                return NotFound();

            return Ok(new { message = "Pin toggled" });
        }

        [HttpPatch("{id}/archive")]
        public IActionResult ToggleArchive(int id)
        {
            if (!_noteService.ToggleArchive(id, GetUserId()))
                return NotFound();

            return Ok(new { message = "Archive toggled" });
        }
    }
}
