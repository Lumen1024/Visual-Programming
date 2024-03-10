using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AvaloniaApplication.Models;

public interface IHaveChildren : IFileSystemItem
{
    public List<IFileSystemItem>? Children { get; }
    
    
}
