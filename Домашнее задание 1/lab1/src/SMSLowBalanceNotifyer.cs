namespace lab1.data;

public class SMSLowBalanceNotifyer : INotifyer
{
    private string _phone;
    private int _lowBalanceValue;

    public SMSLowBalanceNotifyer(string phone, int lowBalanceValue)
    {
        _phone = phone;
        _lowBalanceValue = lowBalanceValue;
    }

    public void Notify(int balance)
    {
        if (balance < _lowBalanceValue)
            Console.WriteLine(_phone + ": баланс меньше чем " + _lowBalanceValue);
    }
}
