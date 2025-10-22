namespace Paylater.TestTask.TaskManager.GatewayRestfullApi.Dtos
{
    public record UserTasksViewDto
    (
        string   UserName
       ,string   TaskId
       ,string   Title
       ,string   Description
       ,string   CreatedAt
       ,string   UpdatedAt
       ,string   Status


    );
}
