using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinFlow.Messaging;
public interface IMessageHandler<in T> where T : class
{
    Task HandleAsync(T message, MessageContext context, CancellationToken ct);
}

public record MessageContext(string MessageId, string? CorrelationId, int DeliveryAttempt);
