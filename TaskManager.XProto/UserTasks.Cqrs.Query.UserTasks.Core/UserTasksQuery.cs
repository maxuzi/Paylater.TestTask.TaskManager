using Paylater.TestTask.TaskManager.UserTasks.Cqrs.Query.UserTasks.Api;
using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.Proto.Common.AppAccessors;
using X.Proto.Common.Entities;
using Paylater.TestTask.TaskManager.UserTasks.Cqrs.Query.Infrastructure.Repository.UserTasks;
using Paylater.TestTask.TaskManager.UserTasks.Cqrs.Query.Infrastructure.Service.User;

namespace Paylater.TestTask.TaskManager.UserTasks.Cqrs.Query.UserTasks.Core
{
    public class UserTasksQuery : XServiceAccessor, IUserTasksQuery
    {
        private readonly IUserTasksRepository _userTasksRepository;
        private readonly IUserService         _userService;

        public UserTasksQuery( IUserTasksRepository pUserTasksRepository, IUserService pUser )
        {
            _userTasksRepository = pUserTasksRepository;
            _userService         = pUser;
        }

        public virtual async Task<XData> GetUserTasksAsync( XData pUserId )
        {
            var taskList = await _userTasksRepository.GetUserTasksAsync(pUserId );
            var userName = await _userService.GetName( pUserId );

            this.addUserNameToTaskList( ref taskList, userName.GetValueOfField( "name" ).ToString()! );

            return taskList;
        }



        protected virtual void addUserNameToTaskList( ref XData rTaskList, string pUserName ) 
        {
            rTaskList.Fields.Add( "UserName" );

            foreach( var row in rTaskList.Rows )
            {
                row.Add( pUserName );
            }
        }
    }
}
