using Autofac;
using Paylater.TestTask.TaskManager.User.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.Proto.Common.AppAccessors;

namespace Paylater.TestTask.TaskManager.User.Core
{
    public class RUser : Module
    {
        protected override void Load( ContainerBuilder builder )
        {
            builder.RegisterType<User>().As<IUser>().SingleInstance();
            builder.RegisterType<User>().Named<XServiceAccessor>( "IUser" ).SingleInstance();
        }
    }
}
