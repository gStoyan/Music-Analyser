
using System.Collections.Generic;

namespace MusicAnalyser.Infrastructure.TextsExtensions
{
    public interface ITextParser
    {
        List<string> ParseCsv(string text);
    }
}
