using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Paylater.TestTask.TaskManager.Core.Users.Entities;
using Paylater.TestTask.TaskManager.Core.Users.Interfaces;
using Paylater.TestTask.TaskManager.WebApp.Dtos;
using Paylater.TestTask.TaskManager.WebApp.Mapping;

namespace Paylater.TestTask.TaskManager.WebApp
{
    [ApiController]
    [Route("task-manager/v1/")]
    //[Authorize(AuthenticationSchemes = "CustomAuth" )]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController( IUserService userService )
        {
            _userService = userService;
        }                                                                                                                

        [HttpPost]
        [ProducesResponseType( typeof( UserDto ), StatusCodes.Status200OK )]
        [Route( "users/user" )]
        public async Task<IActionResult> CreateUser( [FromBody] UserDto userDto )
        {
            var user = UserMapping.UserDtoToUserEntity( userDto );

            await _userService.CreateAsync( user );

            return Ok();
        }


        [HttpGet]
        [ProducesResponseType( typeof( UserDto ), StatusCodes.Status200OK )]
        [ProducesResponseType( StatusCodes.Status404NotFound )]
        [Route( "users/{id}" )]
        public async Task<IActionResult> GetUser( int id )
        {
            var user = await _userService.GetUsersById( id );

            var e = UserMapping.UserEntityToUserDto( user );

            return Ok( UserMapping.UserEntityToUserDto( user ));
        }


        [HttpPost]
        [ProducesResponseType( typeof( UserDto ), StatusCodes.Status200OK )]
        [Route( "users/{user_id}/user_tasks/user_task" )]
        public async Task<IActionResult> AddUserTasks( int user_id, [FromBody] UserTasksDto userTasksDto )
        {
            var userTasks = UserTasksMapping.UserTaskDtoToUserTaskEntity( userTasksDto );

            await _userService.AddUserTaskAsync( userTasks );

            return Ok();
        }


        [HttpPost]
        [ProducesResponseType( typeof( UserDto ), StatusCodes.Status200OK )]
        [Route( "users/{user_id}/user_tasks/{task_id}/user_task/status/{status}" )]
        public async Task<IActionResult> ModifyStatusUserTas( int user_id, int task_id, string status )
        {
            await _userService.ModifyStatusUserTaskAsync( user_id, task_id, status );

            return Ok();
        }

    }


}
