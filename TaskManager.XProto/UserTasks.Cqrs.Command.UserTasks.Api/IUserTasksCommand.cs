using X.Proto.Common.Entities;

namespace Paylater.TestTask.TaskManager.UserTasks.Cqrs.Command.UserTasks.Api
{
    public interface IUserTasksCommand
    {
        Task<XData> CreateAsync( XData pData );

        Task<XData> UpdateStatusAsync( XData pData );
    }
}
