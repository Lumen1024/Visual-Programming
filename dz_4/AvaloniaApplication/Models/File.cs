using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApplication.Models
{
    internal class File : IFileSystemItem
    {
        public string Name => _info.Name;

        public string ImagePath => "/Assets/file.svg";

        public FileInfo _info;

        public File(FileInfo info)
        {
            _info = info;
        }
    }
}
