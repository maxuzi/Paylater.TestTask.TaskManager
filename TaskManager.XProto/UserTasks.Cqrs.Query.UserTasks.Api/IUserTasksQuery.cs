using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.Proto.Common.Entities;

namespace Paylater.TestTask.TaskManager.UserTasks.Cqrs.Query.UserTasks.Api
{
    public interface IUserTasksQuery
    {
        Task<XData> GetUserTasksAsync( XData pUserId );
    }
}
