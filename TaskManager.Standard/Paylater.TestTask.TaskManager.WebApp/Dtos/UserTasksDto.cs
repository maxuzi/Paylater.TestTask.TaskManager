namespace Paylater.TestTask.TaskManager.WebApp.Dtos
{
    public record UserTasksDto
    (
        int      UserId
       ,int      Id
       ,string   Title
       ,string   Description
       ,string   Status
       ,DateTime CreatedAt
       ,DateTime UpdatedAt
    );
}

