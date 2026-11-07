using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinFlow.Messaging;
public interface IMessageBus
{
    Task PublishAsync<T>(T message, string? key = null, CancellationToken ct = default)
        where T : class;
}