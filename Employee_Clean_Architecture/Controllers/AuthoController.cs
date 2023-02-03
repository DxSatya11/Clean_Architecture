using Employee_Application.Commands;
using Employee_Application.Responses;
using Employee_Core.Entities;
using Employee_Core.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Employee_Clean_Architecture.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthoController : ControllerBase
    {
        private readonly IAuthDataRepository<Login>? _authDataRepository;
        private readonly IMediator _mediator;
        public AuthoController(IAuthDataRepository<Login>? authDataRepository, IMediator mediator)
        {
            _authDataRepository = authDataRepository;
            _mediator = mediator;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] Login user)
        {
            var user1 = _authDataRepository.Checkauth(user.UserName, user.Password);
            if (user1 == null)
            {
                return BadRequest("Invalid client request");
            }
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var tokeOptions = new JwtSecurityToken(
                issuer: "https://localhost:7034",
                audience: "https://localhost:7034",
                claims: new List<Claim>(),
                expires: DateTime.Now.AddDays(1),
                signingCredentials: signinCredentials
            );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
            return Ok(new AuthenticateResponse { Token = tokenString });
        }

        [HttpPost("RegisterUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<LoginResponse>> CreateUser([FromBody] CreateLoginCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
