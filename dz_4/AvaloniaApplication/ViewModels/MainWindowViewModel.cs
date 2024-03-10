using System;
using System.Collections.ObjectModel;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using AvaloniaApplication.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AvaloniaApplication.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        [ObservableProperty] private string _currentPath = string.Empty;

        [ObservableProperty] private Bitmap? _image;

        [ObservableProperty] private string _imageName = string.Empty;

        [ObservableProperty] private IFileSystemItem? _selected;

        private ObservableCollection<IFileSystemItem> _items = new();

        public ObservableCollection<IFileSystemItem> Items
        {
            get => _items;
            set => SetProperty(ref _items, value);
        }


        private readonly CustomFileSystem _fileSystem = new();

        public MainWindowViewModel()
        {
            Items = new ObservableCollection<IFileSystemItem>(_fileSystem.CurrentItems);
            
            _fileSystem.OnListPublished += ((items, path) =>
            {
                Items.Clear();
                foreach (var item in items)
                    Items.Add(item);
                CurrentPath = path;
            });

            _fileSystem.OnImagePublished += (path, name) =>
            {
                Console.WriteLine(path);
                //_image = new Bitmap(AssetLoader.Open(new Uri("path")));
                ImageName = name;
            };
        }

        public void Back()
        {
            _fileSystem.Back();
        }

        public void SingleTap()
        {
            if (Selected != null)
                _fileSystem.SelectItem(Selected);
        }

        public void DoubleTap()
        {
            if (Selected != null)
                _fileSystem.ForceSelect(Selected);
        }
    }
}