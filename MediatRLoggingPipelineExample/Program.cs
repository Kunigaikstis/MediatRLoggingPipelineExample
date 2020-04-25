using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace MediatRLoggingPipelineExample
{
    public static class Program
    {

        public static async Task Main(string[] args)
        {
            var mediator = BuildMediator();
            await mediator.Send(new PingCommand(123, "Live message!"));
        }

        private static IMediator BuildMediator()
        {
            var services = new ServiceCollection();
            
            services.AddLogging(options => options.AddConsole());
            
            services.AddMediatR(typeof(Program));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
            
            var provider = services.BuildServiceProvider();
            
            return provider.GetRequiredService<IMediator>();
        }
    }
}