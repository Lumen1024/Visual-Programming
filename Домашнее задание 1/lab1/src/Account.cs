namespace lab1.Notifier;

public class Account
{
    private int _balance;
    private List<INotifyer> _notifiers = new();

    public Account() { }

    public Account(int balance)
    {
        _balance = balance;
    }

    public void AddNotifyer(INotifyer notifyer)
    {
        _notifiers.Add(notifyer);
    }

    public void ChangeBalance(int newBalance)
    {
        _balance = newBalance;
        Notification();
    }

    public int Balance
    {
        get { return _balance; }
    }

    private void Notification()
    {
        Console.WriteLine();
        _notifiers.ForEach(
            (item) =>
            {
                item.Notify(_balance);
            }
        );
    }
}
