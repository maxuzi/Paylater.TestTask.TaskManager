using Microsoft.AspNetCore.Mvc;
using Paylater.TestTask.TaskManager.GatewayRestfullApi.Dtos;
using Paylater.TestTask.TaskManager.GatewayRestfullApi.Mapping;
using System.Security.Cryptography;
using X.Proto.Common.Endpoints.Invoker;
using X.Proto.Common.Entities;

namespace LoanArtefactLens.WebApi.Controllers
{
    [ApiController]
    [Route("task-manager/v1/")]
    //[Authorize(AuthenticationSchemes = "ApiToken")]
    public class UserController : ControllerBase
    {
        private readonly IXInvoker _invoker;

        public UserController( IXInvoker pInvoker )
        {
            _invoker = pInvoker;
        }

        [HttpPost]
        [ProducesResponseType( typeof( UserDto ), StatusCodes.Status200OK )]
        [Route( "users/user" )]
        public async Task<IActionResult> CreateUser( [FromBody] UserDto user )
        {
            var userXData = UserMapping.UserDtoToXData( user );

            var invokerRequest = userXData.CreateRequest( "IUser.CreateAsync" );

            await _invoker.ExecuteCommandAsync( invokerRequest );

            return Ok();
        }


        [HttpGet]
        [ProducesResponseType( typeof( UserDto ), StatusCodes.Status200OK )]
        [ProducesResponseType( StatusCodes.Status404NotFound )]
        [Route( "users" )]
        public async Task<IActionResult> GetUsers()
        {
            var invokerRequest = new XData().CreateRequest( "IUser.GetUserListAsync" );
            var resultJson     = await _invoker.ExecuteCommandAsync( invokerRequest );
            var result         = UserMapping.JsonToUserDto( resultJson );

            return Ok(result);
        }





    }


}
