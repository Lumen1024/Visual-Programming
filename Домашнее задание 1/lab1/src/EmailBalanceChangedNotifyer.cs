namespace lab1.Notifier;

public class EmailBalanceChangedNotifyer : INotifyer
{
    private string _email;

    public EmailBalanceChangedNotifyer(string email)
    {
        _email = email;
    }

    public void Notify(int balance)
    {
        Console.WriteLine(_email + ": баланс изменен, текущий баланс = " + balance);
    }
}
