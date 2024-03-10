using System.IO;

namespace AvaloniaApplication.Models;

public class Image(FileInfo info) : File(info)
{
    public override string IconPath => "/Assets/image.svg";
}