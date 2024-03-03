using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApplication.Models
{
    internal class Directory : IFileSystemItem
    {
        public string Name => _info.Name;

        public string ImagePath => "/Assets/directory.svg";

        public DirectoryInfo _info;

        public Directory(DirectoryInfo info)
        {
            _info = info;
        }
    }
}
