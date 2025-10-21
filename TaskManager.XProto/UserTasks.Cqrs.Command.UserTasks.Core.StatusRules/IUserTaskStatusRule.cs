using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.Proto.Common.Entities;

namespace Paylater.TestTask.TaskManager.UserTasks.Cqrs.Command.UserTasks.Core.StatusRules
{
    public interface IUserTaskStatusRule
    {
        string Check( string pTaskHistory );
    }
}
