using Start_Project_BankAccount;

namespace TestProject1;
public class Tests
{
    [Test]
    public void Deposit_ShouldChangeBalance_WhenCalled()
    {
        // Arrange
        BankAccount bankAccount = new BankAccount(0);

        // Act
        bankAccount.Deposit(50);

        // Assert
        Assert.That(bankAccount.balance, Is.EqualTo(50));
    }

    [Test]
    public void Withdraw_ShouldChangeBalance_WhenWithdrawingLessThanBalance()
    {
        // Arrange
        BankAccount bankAccount = new BankAccount(100);

        // Act
        bankAccount.Withdraw(10);

        // Assert
        Assert.That(bankAccount.balance, Is.EqualTo(90));
    }

    [Test]
    public void Withdraw_ShouldRaiseException_WhenWithdrawingMoreThanBalance()
    {
        // Arrange
        BankAccount bankAccount = new BankAccount(10);

        Assert.Throws<Exception>(() => bankAccount.Withdraw(100));
    }

    [Test]
    public void Send_ShouldTransferMoney_WhenSendingLessThanBalance()
    {
        // Arrange
        BankAccount alice = new BankAccount(100);
        BankAccount bob = new BankAccount(0);

        // Act
        alice.Send(5, bob);

        // Assert
        Assert.That(bob.balance, Is.EqualTo(5));
    }

    [Test]
    public void Send_ShouldRaiseException_WhenSendingMoreThanBalance()
    {
        // Arrange
        BankAccount bob = new BankAccount(100);
        BankAccount alice = new BankAccount(0);

        // Act & Assert
        Assert.Throws<Exception>(() => bob.Send(10000, alice));
    }
}

