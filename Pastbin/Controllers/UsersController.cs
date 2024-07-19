using Microsoft.AspNetCore.Mvc;
using Pastbin.API.Contracts;
using Pastbin.Core.Abstractions;
using Pastbin.Core.Models;
using System.Threading.Tasks.Dataflow;

namespace Pastbin.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController: ControllerBase
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserResponse>>> GetUsers()
        {
            var users = await _usersService.GetAllUsers();

            var response = users.Select(x => new UserResponse(x.Id, x.UserName, x.Name, x.LastName, x.Surname));

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateUser([FromBody] UserRequest request)
        {
            var (user, errors) = Core.Models.User.Create(
                Guid.NewGuid(),
                request.userName,
                request.password,
                request.name,
                request.lastName,
                request.surname);

            if (errors.Count > 0)
            {
                return BadRequest(errors);
            }

            var id = await _usersService.CreateUser(user);

            return Ok(id);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateUser(Guid id, [FromBody] UserRequest updateRequest)
        {
            try
            {
                var updatedId = await _usersService.UpdateUser(
                                      id,
                                      updateRequest.userName,
                                      updateRequest.password,
                                      updateRequest.name,
                                      updateRequest.lastName,
                                      updateRequest.surname
                                      );

                return Ok(updatedId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id:guid}"))]
        public async Task<ActionResult<Guid>> DeleteUser(Guid id)
        {
            try
            {
                var deletedId = await _usersService.DeleteUser(id);
                return Ok(deletedId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
