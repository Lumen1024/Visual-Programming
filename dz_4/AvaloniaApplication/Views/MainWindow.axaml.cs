using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using AvaloniaApplication.Models;

namespace AvaloniaApplication.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void TappedListBox(object? sender, TappedEventArgs e)
        {
            if (e.Source is not IDataContextProvider provider) return;

            if (provider.DataContext is not IFileSystemItem) return;

            if (DataContext is not ViewModels.MainWindowViewModel viewModel) return;

            viewModel.ItemSelected();
        }
    }
}