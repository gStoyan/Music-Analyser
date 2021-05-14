
using System.Collections.Generic;
using System.Linq;

namespace MusicAnalyser.Tests.Extensions
{
    public class FileReader
    {
        public List<string> ReadFile(string path)
        {
            string[] lines = System.IO.File.ReadAllLines(path);
            return lines.ToList();
        }
    }
}
