using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskBoard.API.Contracts;
using TaskBoard.API.Contracts.Projects;
using TaskBoard.Application.Services;
using TaskBoard.Core.Interfaces;
using TaskBoard.Core.Models;

namespace TaskBoard.API.Controllers
{
    [ApiController]
    [Route("projects")]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectsService _projectsService;
        public ProjectsController(IProjectsService projectsService)
        {
            _projectsService = projectsService;
        }

        [HttpPost("create")]
        [Authorize]
        public async Task<ActionResult<Guid>> CreateProject([FromBody] ProjectCreateRequest request)
        {
            var userIdClaim = User.FindFirst("userId")?.Value;

            var (project, error) = Project.Create(
                Guid.NewGuid(),
                request.name,
                request.description,
                Guid.Parse(userIdClaim));

            if (!string.IsNullOrEmpty(error))
            {
                return BadRequest(error);
            }

            var projectId = await _projectsService.CreateProject(project);

            return Ok(projectId);
        }
    }
}
