using Paylater.TestTask.TaskManager.UserTasks.Cqrs.Query.Infrastructure.Repository.UserTasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.Proto.Common.Entities;
using X.Proto.Db.Component.Dml;

namespace Paylater.TestTask.TaskManager.UserTasks.Cqrs.Query.Infrastructure.Repository.UserTasks
{
    public class UserTasksRepository : IUserTasksRepository
    {
        private readonly IXDmlComponent _dmlComponent;

        public UserTasksRepository( IXDmlComponent pDmlComponent )
        {
            _dmlComponent = pDmlComponent;
        }

        public Task<XData> GetUserTasksAsync( XData pUserId )
        {
            return _dmlComponent.Execute( "GetUserTasks", pUserId );
        }
    }
}
