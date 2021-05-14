using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicAnalyser.Infrastructure.NotesExtensions.Implementations
{
    public class NotesTimeCalculator : INotesTimeCalculator
    {
        public int ConvertToMiliSeconds(string time)
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
