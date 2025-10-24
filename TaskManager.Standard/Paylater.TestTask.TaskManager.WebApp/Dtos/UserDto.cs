using Paylater.TestTask.TaskManager.Core.Users.Entities;

namespace Paylater.TestTask.TaskManager.WebApp.Dtos
{
    public record UserDto
    (
        int    Id
       ,string Name

       ,ICollection<UserTasks> Tasks
    );
}
