using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApplication.Models
{
    public class File(FileInfo info) : IFileSystemItem
    {
        public string Name => info.Name;
        public string Path => info.FullName;
        public virtual string IconPath => "/Assets/file.svg";
    }
}