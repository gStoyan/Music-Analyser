using MusicAnalyser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicAnalyser.Infrastructure.NotesExtensions
{
    public interface INotesCreator
    {
        List<Note> CreateNotes(List<string> content);
    }
}
