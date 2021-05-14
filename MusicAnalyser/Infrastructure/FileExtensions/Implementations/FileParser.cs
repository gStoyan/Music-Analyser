using MusicAnalyser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicAnalyser.Infrastructure.FileExtensions.Implementations
{
    public class FileParser : IFileParser
    {
        public List<Note> ParseCsv(List<string> content)
        {
            List<string> notesOnNames = new List<string>();
            List<string> notesOffNames = new List<string>();
            List<int> notesOnTime = new List<int>();
            List<int> notesOffTime = new List<int>();
            content.RemoveAll(s => string.IsNullOrWhiteSpace(s));
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
                    int miliseconds = ConvertToMiliSeconds(time);
                    notesOnNames.Add(noteName);
                    notesOnTime.Add(miliseconds);
                }
                if (noteState == "Note Off")
                {
                    int miliseconds = ConvertToMiliSeconds(time);
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

        private int ConvertToMiliSeconds(string time)
        {
            var timeSplit = time.Split(':');
            var hours = int.Parse(timeSplit[0]);
            var minutes = int.Parse(timeSplit[1]);
            var seconds = int.Parse(timeSplit[2]);
            var miliseconds = int.Parse(timeSplit[3]);

            return miliseconds + seconds * 1000 + minutes * 60000 + hours * 3600000;
        }
    }
}
