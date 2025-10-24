using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paylater.TestTask.TaskManager.Core.Users.Entities
{
    public class UserTasks
    {
        public int      UserId      {get; set;}
        public int      Id          {get; set;}
        public string   Title       {get; set;}
        public string   Description {get; set;}
        public string   Status      {get; set;}
        public DateTime CreatedAt   {get; set;}
        public DateTime UpdatedAt   {get; set;}

        //public User User { get; set; }
    }
}
