using MusicAnalyser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicAnalyser.Infrastructure.FileExtensions
{
    public interface IFileParser
    {
        List<Note> ParseCsv(List<string> content);
    }
}
