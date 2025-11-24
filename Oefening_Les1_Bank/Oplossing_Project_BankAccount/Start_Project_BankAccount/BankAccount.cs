namespace Start_Project_BankAccount;
public class BankAccount
{
    public int balance;

    public BankAccount(int startBalance)
    {
        this.balance = startBalance;
    }

    public void Deposit(int amount)
    {
        balance += amount;
    }

    public void Withdraw(int amount)
    {
        if (balance >= amount)
        {
            balance -= amount;
        }
        else
        {
            throw new Exception("You cannot withdraw more than you have");
        }
    }

    public void Send(int amount, BankAccount otherBankAccount)
    {
        if (balance >= amount)
        {
            Withdraw(balance);
            otherBankAccount.Deposit(amount);
        }
        else
        {
            throw new Exception("You cannot send more than you have");
        }
    }
}
