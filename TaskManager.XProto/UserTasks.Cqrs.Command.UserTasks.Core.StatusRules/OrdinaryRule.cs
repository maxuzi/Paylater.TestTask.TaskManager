using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paylater.TestTask.TaskManager.UserTasks.Cqrs.Command.UserTasks.Core.StatusRules
{
    public class OrdinaryRule : IUserTaskStatusRule
    {
        public string Check( string pTaskHistory )
        {
            return "OK";
        }
    }
}
