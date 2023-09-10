

using Microsoft.AspNetCore.Mvc;

namespace BossaboxBackendChallenge.Test
{

    [Route("api/[controller]")]
    [ApiController]
    public class ToolController: ControllerBase
    {
        private readonly IToolService _toolService;
        public ToolController(IToolService toolService)
        {
            _toolService = toolService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult CreateToll([FromBody] CreatedToolDto dto)
        {
            var tool = _toolService.CreateTool(dto.Title, dto.Link, dto.Description, dto.Tags); ;

            return CreatedAtAction(nameof(GetToolById), new { id = tool.Id }, tool);

        }


        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetToolById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}