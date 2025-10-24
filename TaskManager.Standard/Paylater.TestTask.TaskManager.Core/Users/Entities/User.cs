using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paylater.TestTask.TaskManager.Core.Users.Entities
{
    public class User
    {
        public int    Id   { get; set; }
        public string Name { get; set; }

        public ICollection<UserTasks> Tasks { get; set; }
    }
}
