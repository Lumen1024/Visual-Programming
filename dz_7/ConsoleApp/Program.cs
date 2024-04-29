using System.Collections.ObjectModel;
using ConsoleApp;

var collection = new ObservableCollection<object>();

// Создание объекта наблюдателя
var observer = CollectionObserverFactory.CreateObserver(collection);

// Подписка на уведомления об изменениях и логирование в файл
observer.Subscribe(args =>
{
    LogToFile($"Change Type: {args.Action}, New Items Count: {args.NewItems?.Count}, Old Items Count: {args.OldItems?.Count}");
});

// Пример изменений в коллекции
collection.Add("Item 1");
collection.Add("Item 2");
collection.RemoveAt(0);

// Задержка перед закрытием консоли
Console.ReadLine();
return;

static void LogToFile(string message)
{
    const string filePath = "log.txt";
    Console.WriteLine(message);
    using var writer = File.AppendText(filePath);
    writer.WriteLine($"{DateTime.Now}: {message}");
}