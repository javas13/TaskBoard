using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskBoard.API.Contracts;
using TaskBoard.Core.Interfaces;
using TaskBoard.Core.Models;

namespace TaskBoard.API.Controllers
{
    [ApiController]
    [Route("tasks")]
    public class ObjectivesController : ControllerBase
    {
        private readonly IObjectivesService _objectivesService;
        public ObjectivesController(IObjectivesService objectivesService) 
        {
            _objectivesService = objectivesService;
        }
        [HttpGet]
        public async Task<ActionResult<List<ObjectivesResponse>>> GetObjectives()
        {
            var objectives = await _objectivesService.GetAllObjectives();

            var response = objectives.Select(b => new ObjectivesResponse(
                b.Id,
                b.Name,
                b.Description,
                b.Type));

            return Ok(response);
        }

        [HttpPost("create")]
        public async Task<ActionResult<Guid>> CreateObjective([FromBody] ObjectivesRequest request)
        {
            var (objective, error) = Objective.Create(
                Guid.NewGuid(),
                request.name,
                request.description,
                request.type);

            if (!string.IsNullOrEmpty(error)) 
            { 
                return BadRequest(error);
            }

            var objectiveId = await _objectivesService.CreateObjective(objective);

            return Ok(objectiveId);
        }

        [HttpPut("update/{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateObjectives(Guid id, [FromBody] ObjectivesRequest request)
        {
            var objectiveId = await _objectivesService.UpdateObjective(id, request.name, request.description, request.type);
            return Ok(objectiveId);
        }

        [HttpDelete("delete/{id:guid}")]
        public async Task<ActionResult<Guid>> DeleteObjective(Guid id)
        {
            return Ok(await _objectivesService.DeleteObjective(id));
        }

    }
}
