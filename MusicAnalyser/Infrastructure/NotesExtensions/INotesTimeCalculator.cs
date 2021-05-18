
using MusicAnalyser.Models;
using System.Collections.Generic;

namespace MusicAnalyser.Infrastructure.NotesExtensions
{
    public interface INotesTimeCalculator
    {
        int ConvertToMiliSeconds(string time);
        List<Note> GetNotesWithTime(List<string> noteNames, List<int> notesOnTime, List<int> notesOffTime);

        List<Note> CalculatePause(List<Note> notes);
    }
}
