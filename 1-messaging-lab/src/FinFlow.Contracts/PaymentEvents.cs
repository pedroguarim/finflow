using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinFlow.Contracts;
public record PaymentCreated(
    Guid PaymentId,
    Guid PayerId,
    Guid PayeeId,
    decimal Amount,
    DateTime CreatedAt);
public record PaymentApproved(
    Guid PaymentId,
    DateTime ApprovedAt);
public record PaymentRejected(
    Guid PaymentId,
    string Reason,
    DateTime RejectedAt);