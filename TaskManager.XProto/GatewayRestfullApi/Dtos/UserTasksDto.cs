namespace Paylater.TestTask.TaskManager.GatewayRestfullApi.Dtos
{
    public record UserTasksDto
    (
        DateTime    UserId
       ,DateTime    TaskId
       ,string      Title
       ,string      Description
    );
}

