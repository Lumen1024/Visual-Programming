using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AvaloniaApplication.Models;

public class CustomFileSystem
{
    #region Events

    public delegate void ListPublishedHandler(List<IFileSystemItem> items, string dirPath);

    public event ListPublishedHandler? OnListPublished;

    public delegate void ImagePublishedHandler(string path, string name);

    public event ImagePublishedHandler? OnImagePublished;

    #endregion

    private string _rootPath = string.Empty;

    #region Interaction Methods

    public List<IFileSystemItem> CurrentItems
    {
        get
        {
            if (_rootPath == string.Empty)
            {
                return InitItems;
            }
            else throw new NotImplementedException(); // todo
        }
    }

    private static List<IFileSystemItem> InitItems =>
        DriveInfo
            .GetDrives()
            .ToList()
            .Select(info => new Disk(info) as IFileSystemItem)
            .ToList();


    public void SelectItem(IFileSystemItem item)
    {
        if (item is Image img)
            OnImagePublished?.Invoke(img.Path, img.Name);
    }

    public void ForceSelect(IFileSystemItem item)
    {
        if (item is not IHaveChildren parent) return;

        var children = parent.Children;
        if (children is null) return;

        _rootPath = parent.Path;
        OnListPublished?.Invoke(children, _rootPath);
    }

    public void Back()
    {
        if (_rootPath == string.Empty) return;

        var parent = System.IO.Directory.GetParent(_rootPath);
        if (parent == null)
        {
            _rootPath = string.Empty;
            OnListPublished?.Invoke(InitItems, _rootPath);
        }
        else
        {
            var rt = new Directory(parent);
            _rootPath = rt.Path;
            OnListPublished?.Invoke(rt.Children!, _rootPath);
        }
    }

    

    #endregion
}