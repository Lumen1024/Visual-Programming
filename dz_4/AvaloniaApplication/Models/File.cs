using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApplication.Models
{
    internal class File(FileInfo info) : IFileSystemItem
    {
        public string Name => Info.Name;

        public string ImagePath => "/Assets/file.svg";

        public FileInfo Info = info;
    }
}
