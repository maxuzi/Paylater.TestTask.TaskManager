


using Paylater.TestTask.TaskManager.Core.Users.Entities;
using Paylater.TestTask.TaskManager.WebApp.Dtos;

namespace Paylater.TestTask.TaskManager.WebApp.Mapping
{

    public static class UserTasksMapping
    {

        public static UserTasks UserTaskDtoToUserTaskEntity( UserTasksDto pUserTasksDto )
        {
            var result = new UserTasks() { UserId =       pUserTasksDto.UserId
                                          ,Title =        pUserTasksDto.Title
                                          ,Description =  pUserTasksDto.Description
                                          ,Status =       pUserTasksDto.Status
                                          ,CreatedAt =    pUserTasksDto.CreatedAt
                                          ,UpdatedAt =    pUserTasksDto.UpdatedAt
                                         };

            return result;
        }



    }
}
