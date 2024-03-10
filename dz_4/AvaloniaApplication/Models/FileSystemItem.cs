namespace AvaloniaApplication.Models;

public interface IFileSystemItem
{
    public string Name { get; }
    public string Path { get; }
    public string IconPath { get; }
}