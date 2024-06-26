﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApplication.Models
{
    public class Disk(DriveInfo info) : IHaveChildren
    {
        public string Name => info.Name;
        public string Path => info.Name;
        public string IconPath => "/Assets/disk.svg";
        public List<IFileSystemItem>? Children => GetChildren(info.RootDirectory);
        
        private static List<IFileSystemItem>? GetChildren(DirectoryInfo rootInfo)
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
                        if (new List<string>() { ".png", ".jpg", ".webm", ".jpeg" }.Contains(fileInfo.Extension))
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