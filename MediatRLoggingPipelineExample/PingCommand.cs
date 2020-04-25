using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;

namespace MediatRLoggingPipelineExample
{
    public class PingCommand : IRequest<Unit>
    {
        public int UserId { get; set; }
        public string Message { get; set; }
        
        public PingCommand(int userId, string message)
        {
            UserId = userId;
            Message = message;
        }
    }

    public class PingCommandHandler : IRequestHandler<PingCommand, Unit>
    {
        private readonly ILogger<PingCommand> _logger;

        public PingCommandHandler(ILogger<PingCommand> logger)
        {
            _logger = logger;
        }

        public Task<Unit> Handle(PingCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Pinging {request.UserId.ToString()} with '{request.Message}'");
            return Task.FromResult(Unit.Value);
        }
    }
}