namespace Paylater.TestTask.TaskManager.ObserverService
{
    public static class AddObserverServiceExtension
    {
        public static WebApplicationBuilder AddObserverService( this WebApplicationBuilder builder )
        {
            builder.Services.AddHostedService<ObserverServiceBackground>();

            return builder;
        }
    }
}
