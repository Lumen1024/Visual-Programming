using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApplication.Models
{
    internal class Directory(DirectoryInfo info) : IFileSystemItem
    {
        public string Name => Info.Name;

        public string ImagePath => "/Assets/directory.svg";

        public DirectoryInfo Info = info;
    }
}
