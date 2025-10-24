using Paylater.TestTask.TaskManager.Core.Users.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paylater.TestTask.TaskManager.Infrastructure.Users
{
    public interface IUserRepository
    {
        Task CreateAsync( User user );

        Task<User> GetUsersById( int userId );

        Task CreateUserTask( UserTasks userTasks );

        Task UpdateStatusUserTask( int userId, int taskId, string status );
    }
}
