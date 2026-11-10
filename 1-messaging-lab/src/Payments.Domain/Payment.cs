using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Domain;
public class Payment
{
    public Guid Id { get; private set; }
    public Guid PayerId { get; private set; }
    public Guid PayeeId { get; private set; }
    public decimal Amount { get; private set; }
    public PaymentStatus Status { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public string? RejectionReason { get; private set; }

    private Payment() { }
    public static Payment Create(Guid payerId, Guid payeeId, decimal amount)
    {
        if (amount <= 0)
            throw new DomainException("The amount must be greater than zero.");

        if (payerId == payeeId)
            throw new DomainException("Payer and payee cannot be the same account.");

        return new Payment
        {
            Id = Guid.NewGuid(),
            PayerId = payerId,
            PayeeId = payeeId,
            Amount = amount,
            Status = PaymentStatus.Pending,
            CreatedAt = DateTime.UtcNow
        };
    }
    public void Approve()
    {
        if (Status != PaymentStatus.Pending)
            throw new DomainException("Only pending payments can be approved.");
        Status = PaymentStatus.Approved;
    }
    public void Reject(string reason)
    {
        if (Status != PaymentStatus.Pending)
            throw new DomainException("Only pending payments can be rejected.");
        Status = PaymentStatus.Rejected;
        RejectionReason = reason;
    }
}
