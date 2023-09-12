﻿

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
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult GetToolById(Guid id)
        {
            var tool = _toolService.FindToolById(id);
            if (tool == null)
            {
                return NotFound();
            }

            return Ok(tool);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult GetAllToolsByTag([FromQuery] string  tag)
        {
            var tool = _toolService.FindAllToolByTag(tag);
            if (tool.Count == 0)
            {
                return NotFound();
            }

            return Ok(tool);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteToolByID(Guid id)
        {
            var success = _toolService.DeleteById(id);
            if (success)
            {
                return NoContent();
            }

            return NotFound();
        }


    }
}