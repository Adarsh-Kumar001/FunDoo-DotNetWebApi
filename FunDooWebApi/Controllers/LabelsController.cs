using FunDooBusiness.Interfaces;
using Microsoft.AspNetCore.Mvc;
using FunDooRepository.Entities;

namespace FunDooWebApi.Controllers
{

    [ApiController]
    [Route("api/labels")]
    public class LabelsController : ControllerBase
    {
        private readonly ILabelService _labelService;

        public LabelsController(ILabelService labelService)
        {
            _labelService = labelService;
        }

        [HttpPost]
        public IActionResult Create(Label label)
        {
            return Ok(_labelService.Create(label));
        }

        [HttpGet("{userId}")]
        public IActionResult GetAll(long userId)
        {
            return Ok(_labelService.GetAll(userId));
        }
    }
        
}
