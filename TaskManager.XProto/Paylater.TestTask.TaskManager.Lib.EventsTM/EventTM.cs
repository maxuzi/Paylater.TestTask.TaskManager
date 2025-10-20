using Autofac;
using X.Proto.Common.Events;
using X.Proto.Common.Logging.NLog;
using X.Proto.Component.ServiceBrokers.RabbitMQ;

namespace Paylater.TestTask.TaskManager.Lib.EventsTM
{
    public class EventTM : IXEvent
    {
        private readonly IXRabbitMQ _rabbit;
        private readonly XLoggingNLog _nLog;

        public EventTM( IXRabbitMQ pRabbit, XLoggingNLog pNLog )
        {
            _rabbit = pRabbit;
            _nLog   = pNLog;
        }

        public async Task Create( string pText, params object[] pParams )
        {
            await _nLog.Create( pText, pParams );

            _rabbit.Publish( "AppEvents", pParams[0].ToString() );
        }

        
    }
}
