using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Payments.Domain;

namespace Payments.UnitTests;

public class PaymentTests
{
    [Fact]
    public void Create_WithValidData_ShouldStartAsPending()
    {
        // Arrange
        var payerId = Guid.NewGuid();
        var payeeId = Guid.NewGuid();

        // Act
        var payment = Payment.Create(payerId, payeeId, 100m);

        // Assert
        payment.Id.Should().NotBeEmpty();
        payment.PayerId.Should().Be(payerId);
        payment.PayeeId.Should().Be(payeeId);
        payment.Amount.Should().Be(100m);
        payment.Status.Should().Be(PaymentStatus.Pending);
    }
    [Theory]
    [InlineData(0)]
    [InlineData(-10)]
    [InlineData(-0.01)]
    public void Create_WithNonPositiveAmount_ShouldThrowDomainException(double amount)
    {
        var act = () => Payment.Create(Guid.NewGuid(), Guid.NewGuid(), (decimal)amount);

        act.Should().Throw<DomainException>()
           .WithMessage("*amount*");
    }

    [Fact]
    public void Create_WithSamePayerAndPayee_ShouldThrowDomainException()
    {
        var sameId = Guid.NewGuid();

        var act = () => Payment.Create(sameId, sameId, 50m);

        act.Should().Throw<DomainException>()
           .WithMessage("*same*");
    }
}