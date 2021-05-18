using MusicAnalyser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicAnalyser.Infrastructure.NotesExtensions.Implementations
{
    public class NotesCreator : INotesCreator
    {
        private INotesTimeCalculator noteTimeCalculator;

        public NotesCreator()
        {
            this.noteTimeCalculator = new NotesTimeCalculator();
        }
        public List<Note> CreateNotes(List<string> content)
        {
            int id = 1;
            List<Note> notes = new List<Note>();
            content.RemoveAll(s => string.IsNullOrWhiteSpace(s)); //Remove White Spaces and new Lines from csv file
            foreach (var line in content)
            {
                //Split Line {time},{length,{name},{value}
                var splitLine = line.Split(',');
                int time = this.noteTimeCalculator.ConvertToMiliSeconds(splitLine[0]);
                int length = this.noteTimeCalculator.ConvertToMiliSeconds(splitLine[1]);
                string noteName = splitLine[2];
                int tone = int.Parse(splitLine[3]);
                notes.Add(new Note
                {
                    Id = ++id,
                    Name = noteName,
                    Time = time,
                    Length = length,
                    Tone = tone,
                    Pause = 0
                });
            }
            notes = this.noteTimeCalculator.CalculatePause(notes);
            return notes;
        }
    }
}
