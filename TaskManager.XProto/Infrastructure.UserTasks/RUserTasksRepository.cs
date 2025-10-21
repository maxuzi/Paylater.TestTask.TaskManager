using Autofac;
using Autofac.Extras.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paylater.TestTask.TaskManager.UserTasks.Cqrs.Query.Infrastructure.Repository.UserTasks
{
    public class RUserTasksRepository : Module
    {
        protected override void Load( ContainerBuilder builder )
        {
            builder.RegisterType<UserTasksRepository>().As<IUserTasksRepository>().EnableClassInterceptors().InterceptedBy( "EVENT" ).SingleInstance();
        }
    }
}
