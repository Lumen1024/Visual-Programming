using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApplication.Models
{
    public interface IFileSystemItem
    {
        public string Name { get; }
        public string ImagePath { get; }
    }
}
