using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.Proto.Common.Endpoints.Invoker;
using X.Proto.Common.Entities;

namespace Paylater.TestTask.TaskManager.UserTasks.Cqrs.Query.Infrastructure.Service.User
{
    public class UserService : IUserService
    {
        private readonly IXInvoker _invoker;

        public UserService( IXInvoker pInvoker )
        {
            _invoker = pInvoker;
        }

        public async Task<XData> GetName( XData pUserId )
        {
            var invokerRequest = pUserId.CreateRequest( "IUser.GetUserNameAsync" );
            var resultJson = await _invoker.ExecuteCommandAsync( invokerRequest );
            var result = new XData( resultJson );

            return result;
        }
    }
}
