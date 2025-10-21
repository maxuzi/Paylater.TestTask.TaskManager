using Autofac;
using Autofac.Extras.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paylater.TestTask.TaskManager.UserTasks.Cqrs.Query.Infrastructure.Service.User
{
    public class RUserService : Module
    {
        protected override void Load( ContainerBuilder builder )
        {
            builder.RegisterType<UserService>().As<IUserService>().EnableClassInterceptors().InterceptedBy( "EVENT" ).SingleInstance();
        }
    }
}
