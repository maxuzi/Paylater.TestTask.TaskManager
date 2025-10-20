using Autofac;
using Autofac.Extras.DynamicProxy;
using Paylater.TestTask.TaskManager.User.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.Proto.Common.AppAccessors;
using X.Proto.Common.Events;

namespace Paylater.TestTask.TaskManager.User.Core
{
    public class RUser : Module
    {
        protected override void Load( ContainerBuilder builder )
        {
            builder.RegisterType<User>()
                   .Named<XServiceAccessor>( "IUser" )
                   .As<IUser>()
                   .EnableClassInterceptors() 
                   .InterceptedBy( "EVENT" )
                   .SingleInstance();

            //builder.RegisterType<User>().As<IUser>().SingleInstance();
            //builder.RegisterType<User>().Named<XServiceAccessor>( "IUser" ).SingleInstance();
        }
    }
}
