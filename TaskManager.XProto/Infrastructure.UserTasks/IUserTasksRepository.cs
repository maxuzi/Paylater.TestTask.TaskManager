using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.Proto.Common.Entities;

namespace Paylater.TestTask.TaskManager.UserTasks.Cqrs.Query.Infrastructure.Repository.UserTasks
{
    public interface IUserTasksRepository
    {
        Task<XData> GetUserTasksAsync( XData pUserId );
    }
}
