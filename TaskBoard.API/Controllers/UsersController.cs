using Swashbuckle.AspNetCore.Annotations;
using TaskBoard.API.Contracts;
using Microsoft.AspNetCore.Mvc;
using TaskBoard.API.Contracts.Users;
using TaskBoard.Application.Services;
using TaskBoard.Core.Interfaces;
using TaskBoard.Core.Models;

namespace TaskBoard.API.Controllers
{
    [ApiController]
    [Route("users")]
    public class UsersController: ControllerBase
    {
        private readonly IUsersService _usersService;
        private IHttpContextAccessor _contextAccessor;
        public UsersController(IUsersService usersService, IHttpContextAccessor contextAccessor)
        {
            _usersService = usersService;
            _contextAccessor = contextAccessor;
        }

        [HttpPost("register")]
        public async Task<IResult> Register(RegisterUserRequest request)
        {
            await _usersService.Register(request.firstname, request.surname, request.email, request.password);

            return Results.Ok();
        }

        [HttpPost("login")]
        public async Task<IResult> Login([FromBody]LoginUserRequest request)
        {
            var token = await _usersService.Login(request.email, request.password);
            if(token == null)
            {
                return Results.BadRequest("email or password incorrect");
            }
            else
            {
                HttpContext context = this._contextAccessor.HttpContext;

                context.Response.Cookies.Append("non-interest-cookie", token);

                return Results.Ok();
            }
        }
    }
}
