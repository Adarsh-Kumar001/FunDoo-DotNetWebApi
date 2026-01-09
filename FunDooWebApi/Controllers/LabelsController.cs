using FunDooBusiness.Interfaces;
using FunDooModels.DTOs.Labels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

[Authorize]
[ApiController]
[Route("api/labels")]
public class LabelController : ControllerBase
{
    private readonly ILabelService _labelService;

    public LabelController(ILabelService labelService)
    {
        _labelService = labelService;
    }

    private int UserId =>
        int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

    [HttpPost]
    public async Task<IActionResult> Create(CreateLabelDTO dto)
    {
        return Ok(await _labelService.CreateLabel(UserId, dto));
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _labelService.GetAllLabels(UserId));
    }

    [HttpPut("{labelId}")]
    public async Task<IActionResult> Update(int labelId, UpdateLabelDTO dto)
    {
        return Ok(await _labelService.UpdateLabel(labelId, UserId, dto));
    }

    [HttpDelete("{labelId}")]
    public async Task<IActionResult> Delete(int labelId)
    {
        return Ok(await _labelService.DeleteLabel(labelId, UserId));
    }

    [HttpPost("{labelId}/notes/{noteId}")]
    public async Task<IActionResult> AddLabelToNote(int labelId, int noteId)
    {
        return Ok(await _labelService.AddLabelToNote(noteId, labelId));
    }

    [HttpDelete("{labelId}/notes/{noteId}")]
    public async Task<IActionResult> RemoveLabelFromNote(int labelId, int noteId)
    {
        return Ok(await _labelService.RemoveLabelFromNote(noteId, labelId));
    }
}
