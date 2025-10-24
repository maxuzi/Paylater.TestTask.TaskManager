using Microsoft.EntityFrameworkCore;
using Paylater.TestTask.TaskManager.Core.Users.Entities;
using Paylater.TestTask.TaskManager.Db.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paylater.TestTask.TaskManager.Infrastructure.Users
{
    public class UserRepositoryEF : IUserRepository
    {
        private readonly UserManagerDbContext _dbContext;

        public UserRepositoryEF( UserManagerDbContext dbContext )
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync( User user )
        {
            _dbContext.UserTM.Add( user );
            
            await _dbContext.SaveChangesAsync(); 
        }


        public async Task<User> GetUsersById( int userId )
        {
            //return await _dbContext.UserTM.FindAsync( userId );

            return await _dbContext.UserTM.Include( u => u.Tasks ) 
                                          .FirstOrDefaultAsync( u => u.Id == userId );
        }

        public async  Task CreateUserTask( UserTasks userTasks )
        {
            _dbContext.UserTasksTM.Add( userTasks );

            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateStatusUserTask( int userId, int taskId, string status )
        {
            var task = await _dbContext.UserTasksTM.FindAsync( userId, taskId );

            if( task == null )
            {
                throw new InvalidOperationException( "Task not found" );
            }

            task.Status = status;
            task.UpdatedAt = DateTime.UtcNow;

            await _dbContext.SaveChangesAsync();
        }
    }
}
