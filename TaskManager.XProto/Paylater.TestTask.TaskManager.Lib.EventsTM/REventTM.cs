using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.Proto.Common.Events;
using X.Proto.Common.Logging.NLog;
using X.Proto.Component.ServiceBrokers.RabbitMQ;

namespace Paylater.TestTask.TaskManager.Lib.EventsTM
{
    public class REventTM : Module
    {
        protected override void Load( ContainerBuilder builder )
        {
            builder.RegisterType<EventTM>().As<IXEvent>().SingleInstance();
          //  builder.RegisterType<XRabbitMQ>().SingleInstance();
            builder.RegisterType<XLoggingNLog>().SingleInstance();
        }
    }
}
