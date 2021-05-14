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
        public List<Note> ParseCsv(List<string> content)
        {
            List<string> notesOnNames = new List<string>();
            List<string> notesOffNames = new List<string>();
            List<int> notesOnTime = new List<int>();
            List<int> notesOffTime = new List<int>();
            content.RemoveAll(s => string.IsNullOrWhiteSpace(s)); //Remove White Spaces and new Lines from csv file
            foreach (var line in content)
            {               
                var splitLine = line.Split(',');
                string noteState = splitLine[4].Trim();
                string time = splitLine[2];
                string noteName = splitLine[6];
                if (noteState != "Note On" && noteState != "Note Off")
                {
                    continue;
                }
                if (noteState == "Note On")
                {
                    int miliseconds = this.noteTimeCalculator.ConvertToMiliSeconds(time);
                    notesOnNames.Add(noteName);
                    notesOnTime.Add(miliseconds);
                }
                if (noteState == "Note Off")
                {
                    int miliseconds = this.noteTimeCalculator.ConvertToMiliSeconds(time);
                    notesOffNames.Add(noteName);
                    notesOffTime.Add(miliseconds);
                }
            }
            var notes = GetNotesWithTime(notesOnNames,notesOnTime,notesOffTime);
            return notes;
        }


        private List<Note> GetNotesWithTime(List<string> noteNames, List<int> notesOnTime, List<int> notesOffTime)
        {
            List<Note> notes = new List<Note>();
            List<int> notesTime = new List<int>();
            int pause = 0;
            for (int i = 0; i < notesOnTime.Count; i++)
            {
                notesTime.Add(notesOffTime[i] - notesOnTime[i]);
                           
            }

            for (int i = 0; i < noteNames.Count; i++)
            {
                if (i + 1 < notesOnTime.Count)
                {
                    pause = notesOnTime[i + 1] - notesOffTime[i];
                }
                notes.Add(new Note
                {
                    Id = i+1,
                    Name = noteNames[i].Split('-')[1],
                    Tone = int.Parse(noteNames[i].Split('-')[0]),
                    Time = notesTime[i],
                    Pause = pause
                });
            }
            return notes;
        }
    }
}
