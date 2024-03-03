using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApplication.Models
{
    internal class Disk : IFileSystemItem
    {
        public string Name => _info.Name;

        public string ImagePath => "/Assets/disk.svg";

        public DriveInfo _info;

        public Disk(DriveInfo info)
        {
            _info = info;
        }
    }
}

