using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AvaloniaApplication.Models
{
    internal class Directory(DirectoryInfo info) : IHaveChildren
    {
        public string Name => info.Name;
        public string Path => info.FullName;
        public string IconPath => "/Assets/directory.svg";
        public List<IFileSystemItem>? Children => GetChildren(info);
        
        public static List<IFileSystemItem>? GetChildren(DirectoryInfo rootInfo)
        {
            try
            {
                var directories = rootInfo.GetDirectories()
                    .ToList()
                    .Select(directoryInfo => new Directory(directoryInfo) as IFileSystemItem)
                    .ToList();
                var files = rootInfo.GetFiles().ToList()
                    .Select(fileInfo =>
                    {
                        if (new List<string>() { ".png", ".jpg", ".webm" }.Contains(fileInfo.Extension))
                            return new Image(fileInfo) as IFileSystemItem;
                        return new File(fileInfo) as IFileSystemItem;
                    }).ToList();

                directories.AddRange(files);
                return directories;
            }
            catch
            {
                return null;
            }
        }
    }
}