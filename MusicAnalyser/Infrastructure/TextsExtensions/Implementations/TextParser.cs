
using System.Collections.Generic;
using System.Linq;

namespace MusicAnalyser.Infrastructure.TextsExtensions.Implementations
{
    public class TextParser : ITextParser
    {
        public List<string> ParseCsv(string text)=>
            text.Split(new[] { '\r', '\n' }).ToList();
    }
}
