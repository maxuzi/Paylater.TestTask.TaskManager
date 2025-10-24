using Paylater.TestTask.TaskManager.Core.Users.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paylater.TestTask.TaskManager.Core.Users.Interfaces
{
    public interface IUserService
    {
        Task CreateAsync( User user );

        Task<User> GetUsersById( int userId );

        Task AddUserTaskAsync( UserTasks userTasks );

        Task ModifyStatusUserTaskAsync( int userId, int taskId, string status );

    }
}
