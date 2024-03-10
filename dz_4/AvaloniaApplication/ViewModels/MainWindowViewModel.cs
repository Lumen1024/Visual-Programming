using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using AvaloniaApplication.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AvaloniaApplication.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        [ObservableProperty]
        private string _currentPath = "...";

        [ObservableProperty]
        private IFileSystemItem _selected;
        
        public ObservableCollection<IFileSystemItem> _items = new();

        public ObservableCollection<IFileSystemItem> Items
        {
            get => _items;
            set => SetProperty(ref _items, value);
        }

        private bool _homed = true;

        public MainWindowViewModel()
        {
            Home();
        }
        
        public void Back()
        {
            foreach (var item in Items)
            {
                if (item.Name == "C:\\")
                    _homed = true;
            }
            if (_homed) return;
            var dr = System.IO.Directory.GetParent(CurrentPath);
            if (dr == null)
            {
                Home();
                return;
            }
            var directories = dr.GetDirectories();
            CurrentPath = TruncateString(dr.FullName, 30);
            var files = dr.GetFiles();
            Items.Clear();
            foreach (var dir in directories)
            {
                Items.Add(new Models.Directory(dir));
            }
            foreach (var f in files)
            {
                Items.Add(new Models.File(f));
            }
        }

        [RelayCommand]
        private void Home()
        {
            var drives = DriveInfo.GetDrives();
            Items.Clear();
            CurrentPath = "...";
            foreach (var drive in drives)
            {
                if (drive.DriveFormat != "FAT32")
                    Items.Add(new Disk(drive));
            }
        }

        public void ItemSelected()
        {
            if (Selected is Disk)
            {
                var directories = (Selected as Disk).Info.RootDirectory.GetDirectories();
                var files = (Selected as Models.Disk).Info.RootDirectory.GetFiles();

                CurrentPath = (Selected as Disk).Info.RootDirectory.FullName;
                Items.Clear();
                foreach (var dir in directories)
                {
                    Items.Add(new Models.Directory(dir));
                }
                foreach (var f in files)
                {
                    Items.Add(new Models.File(f));
                }
                _homed = false;
            }
            else if (Selected is Models.Directory) 
            {
                if ((Selected as Models.Directory).Info.Attributes.HasFlag(FileAttributes.System)) return;

                var directories = (Selected as Models.Directory).Info.GetDirectories();

                CurrentPath = TruncateString((Selected as Models.Directory).Info.FullName, 30);
                var files = (Selected as Models.Directory).Info.GetFiles();
                Items.Clear();
                foreach (var dir in directories)
                {
                    Items.Add(new Models.Directory(dir));
                }
                foreach (var f in files)
                {
                    Items.Add(new Models.File(f));
                }
                _homed = false;
            }
            else if (Selected is Models.File)
            {
                ShowOpenWithDialog((Selected as Models.File).Info.FullName);
            }
        }

        public static void ShowOpenWithDialog(string path)
        {
            var args = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "shell32.dll");
            args += ",OpenAs_RunDLL " + path;
            Process.Start("rundll32.exe", args);
        }

        public static string TruncateString(string input, int maxLength)
        {
            if (input.Length > maxLength)
            {
                // Обрезаем начало строки до нужной длины
                return input;//input.Substring(input.Length - maxLength);
            }
            else
            {
                // Если длина строки не превышает максимальное значение, возвращаем исходную строку
                return input;
            }
        }
    }
}
