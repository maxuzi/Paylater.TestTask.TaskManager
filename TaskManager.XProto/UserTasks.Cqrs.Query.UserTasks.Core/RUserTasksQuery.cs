using Autofac;
using Autofac.Extras.DynamicProxy;
using Paylater.TestTask.TaskManager.UserTasks.Cqrs.Query.UserTasks.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.Proto.Common.AppAccessors;

namespace Paylater.TestTask.TaskManager.UserTasks.Cqrs.Query.UserTasks.Core
{
    public class RUserTasksQuery : Module
    {
        protected override void Load( ContainerBuilder builder )
        {
            builder.RegisterType<UserTasksQuery>()
                   .Named<XServiceAccessor>( "IUserTasksQuery" )
                   .As<IUserTasksQuery>()
                   .EnableClassInterceptors()
                   .InterceptedBy( "EVENT" )
                   .SingleInstance();
        }
    }
}
