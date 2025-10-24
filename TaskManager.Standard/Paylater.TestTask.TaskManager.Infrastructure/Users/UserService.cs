using Microsoft.EntityFrameworkCore;
using Paylater.TestTask.TaskManager.Core.Users.Entities;
using Paylater.TestTask.TaskManager.Core.Users.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paylater.TestTask.TaskManager.Infrastructure.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService( IUserRepository pUserRepository )
        {
            _userRepository = pUserRepository;
        }

        public async Task CreateAsync( User user )
        {
            await _userRepository.CreateAsync( user );
        }

        public Task<User> GetUsersById( int userId )
        {
            return _userRepository.GetUsersById( userId );
        }

        public async Task AddUserTaskAsync( UserTasks userTasks )
        {
            await _userRepository.CreateUserTask( userTasks );
        }

        public async Task ModifyStatusUserTaskAsync( int userId, int taskId, string status )
        {
            await _userRepository.UpdateStatusUserTask( userId, taskId, status );
        }
    }
}
