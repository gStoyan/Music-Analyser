using MusicAnalyser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicAnalyser.Infrastructure.NotesExtensions.Implementations
{
    public class NotesTimeCalculator : INotesTimeCalculator
    {
        public List<Note> CalculatePause(List<Note> notes)
        {
            for (int i = 0; i < notes.Count; i++)
            {
                if (i +1<notes.Count)
                {
                    int currentTime = notes[i].Time;
                    int nextTime = notes[i + 1].Time;
                    int currentLength = notes[i].Length;
                    notes[i].Pause = nextTime - (currentLength + currentTime );
                }
            }
            return notes;
        }

        public int ConvertToMiliSeconds(string time)
        {
            // Format : 0:0:0:0
            var timeSplit = time.Split(':');
            var hours = int.Parse(timeSplit[0]);
            var minutes = int.Parse(timeSplit[1]);
            var seconds = int.Parse(timeSplit[2]);
            var miliseconds = int.Parse(timeSplit[3]);

            return miliseconds + seconds * 1000 + minutes * 60000 + hours * 3600000;
        }

        public List<Note> GetNotesWithTime(List<string> noteNames, List<int> notesOnTime, List<int> notesOffTime)
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
                    Id = i + 1,
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
