using Autofac;
using Autofac.Extras.DynamicProxy;
using Paylater.TestTask.TaskManager.UserTasks.Cqrs.Command.UserTasks.Api;
using Paylater.TestTask.TaskManager.UserTasks.Cqrs.Command.UserTasks.Core.StatusRules;
using X.Proto.Common.AppAccessors;


namespace Paylater.TestTask.TaskManager.UserTasks.Cqrs.Command.UserTasks.Core
{
    public class RUserTasksCommand : Module
    {
        protected override void Load( ContainerBuilder builder )
        {
            builder.RegisterType<UserTasksCommand>()
                   .Named<XServiceAccessor>( "IUserTasksCommand" )
                   .As<IUserTasksCommand>()
                   .EnableClassInterceptors()
                   .InterceptedBy( "EVENT" )
                   .SingleInstance();

            builder.RegisterType<OrdinaryRule>().As<IUserTaskStatusRule>().SingleInstance();
        }
    }
}
