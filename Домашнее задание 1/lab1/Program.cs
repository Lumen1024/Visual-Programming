using lab1.data;

var account = new Account(50);

account.AddNotifyer(new EmailBalanceChangedNotifyer("artur@gmail.com"));
account.AddNotifyer(new EmailBalanceChangedNotifyer("misha@gmail.com"));
account.AddNotifyer(new SMSLowBalanceNotifyer("+7(923) 221 44-44", 20));
account.AddNotifyer(new SMSLowBalanceNotifyer("+55(111) 221 00-00", 40));

account.ChangeBalance(100);
account.ChangeBalance(5);
account.ChangeBalance(50);
account.ChangeBalance(30);

Console.WriteLine();
