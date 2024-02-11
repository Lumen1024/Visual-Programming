using System;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace AvaloniaApp;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

    }

    public void ClickHandler(object sender, RoutedEventArgs args)
    {
        var button = sender as Button;
        colorRectangle.Fill = button?.Background;
    }
}