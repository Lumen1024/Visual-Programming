using System.Reactive.Subjects;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace ConsoleApp;


public static class CollectionObserverFactory
{
    public static IObservable<NotifyCollectionChangedEventArgs> CreateObserver(ObservableCollection<object> collection)
    {
        var subject = new Subject<NotifyCollectionChangedEventArgs>();
        collection.CollectionChanged += (sender, args) => subject.OnNext(args);
        return subject;
    }
}