
using System.Threading;
using X.Proto.Component.ServiceBrokers.RabbitMQ;

namespace Paylater.TestTask.TaskManager.ObserverService
{
    public class ObserverServiceBackground : BackgroundService
    {

        private readonly IXRabbitMQ _rabbit;

        public ObserverServiceBackground( IXRabbitMQ pRabbit )
        {
            _rabbit = pRabbit;
        }

        protected async override Task ExecuteAsync( CancellationToken stoppingToken )
        {
            while( !stoppingToken.IsCancellationRequested )
            {
                var message = _rabbit.Consume( "AppEvents" );

                if( null != message )
                {
                    await this.logMessage( message );
                }
                
            }

            
        }

        private async Task logMessage( string pMessage )
        {
            var key = pMessage.Split( " " )[0];

            if( ObservableEvents.Contains( key ) )
            {
                try
                {
                    await semaphoreSlim.WaitAsync();
                    using( StreamWriter file = new StreamWriter( Path.Combine( Environment.CurrentDirectory, "log.txt" ), true ) )
                    {
                        await file.WriteAsync( $"{DateTime.Now} --- {pMessage} {Environment.NewLine}" );
                    }
                }
                finally
                {
                    semaphoreSlim.Release();
                }
            }
        }

        private static readonly SemaphoreSlim semaphoreSlim = new SemaphoreSlim( 1, 1 );
        private static List<string> ObservableEvents = new List<string>() { "Paylater.TestTask.TaskManager.UserTasks.Cqrs.Command.UserTasks.Core.UserTasksCommand_CreateAsync"
                                                                           ,"Paylater.TestTask.TaskManager.UserTasks.Cqrs.Command.UserTasks.Core.UserTasksCommand_UpdateStatusAsync"
                                                                          };
    }
}
