using Microsoft.AspNetCore.Mvc;
using Paylater.TestTask.TaskManager.GatewayRestfullApi.Dtos;
using Paylater.TestTask.TaskManager.GatewayRestfullApi.Mapping;
using System.Security.Cryptography;
using X.Proto.Common.Endpoints.Invoker;
using X.Proto.Common.Entities;

namespace Paylater.TestTask.TaskManager.GatewayRestfullApi.UserTasks
{
    [ApiController]
    [Route("task-manager/v1/")]
    //[Authorize(AuthenticationSchemes = "ApiToken")]
    public class UserTasksController : ControllerBase
    {
        private readonly IXInvoker _invoker;

        public UserTasksController( IXInvoker pInvoker )
        {
            _invoker = pInvoker;
        }

        [HttpPost]
        [ProducesResponseType( typeof( UserTasksDto ), StatusCodes.Status200OK )]
        [Route( "user-tasks/task" )]
        public async Task<IActionResult> CreateUserTask( [FromBody] UserTasksDto task )
        {
            var taskXData      = UserTasksMapping.UserTaskDtoToXData( task );
            var invokerRequest = taskXData.CreateRequest( "IUserTasksCommand.CreateAsync" );

            await _invoker.ExecuteCommandAsync( invokerRequest );

            return Ok();
        }

        [HttpPut]
        [ProducesResponseType( StatusCodes.Status200OK )]
        [Route( "users/{user_id}/user-tasks/{task_id}/status-code/{status_code}" )]
        public async Task<IActionResult> UpdateStatus( DateTime task_id, DateTime user_id, string status_code )
        {
            var taskXData      = UserTasksMapping.UpdateStatusDtoToXData( user_id, task_id, status_code );
            var invokerRequest = taskXData.CreateRequest( "IUserTasksCommand.UpdateStatusAsync" );

            await _invoker.ExecuteCommandAsync( invokerRequest );

            return Ok();
        }

        [HttpGet]
        [ProducesResponseType( typeof( UserTasksViewDto ), StatusCodes.Status200OK )]
        [ProducesResponseType( StatusCodes.Status404NotFound )]
        [Route( "users/{user_id}/user-tasks/" )]
        public async Task<IActionResult> GetUsers( DateTime user_id )
        {

            var userIdXData    = UserTasksMapping.UserIdDtoToXData( user_id );
            var invokerRequest = userIdXData.CreateRequest( "IUserTasksQuery.GetUserTasksAsync" );
            var resultJson     = await _invoker.ExecuteCommandAsync( invokerRequest );
            var result         = UserTasksMapping.JsonToUserTaskDto( resultJson );

            return Ok( result );
        }
    }
}
