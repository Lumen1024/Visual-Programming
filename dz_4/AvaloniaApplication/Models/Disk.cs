using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApplication.Models
{
    internal class Disk(DriveInfo info) : IFileSystemItem
    {
        public string Name => Info.Name;

        public string ImagePath => "/Assets/disk.svg";

        public DriveInfo Info = info;
    }
}

