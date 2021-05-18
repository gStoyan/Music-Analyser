using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Interaction;
using System;
using System.Collections.Generic;
using System.IO;

namespace MusicAnalyser.Infrastructure.MIDIExtensions.Implementations
{
    public class MidiParser : IMidiParser
    {
        private string midiPath = Path.Combine(Environment.CurrentDirectory, @"../MusicAnalyser.Tests\Extensions\TestFiles\song.mid");
        private string txtPath = Path.Combine(Environment.CurrentDirectory, @"../MusicAnalyser.Tests\Extensions\TestFiles\notes.csv");

        public void CreateTxt()
        {
            MidiFile file = MidiFile.Read(midiPath);
            IEnumerable<Note> notes = file.GetNotes();
            TempoMap tempoMap = file.GetTempoMap();
            foreach (var note in notes)
            {
                MetricTimeSpan metricTime = note.TimeAs<MetricTimeSpan>(tempoMap);
                MetricTimeSpan metricLength = note.LengthAs<MetricTimeSpan>(tempoMap);
            }
            using (StreamWriter newTask = new StreamWriter(this.txtPath, false))
            {
                foreach (var note in notes)
                {
                    MetricTimeSpan metricTime = note.TimeAs<MetricTimeSpan>(tempoMap);
                    MetricTimeSpan metricLength = note.LengthAs<MetricTimeSpan>(tempoMap);
                    var name = note.NoteName;
                    var value = note.NoteNumber;
                    newTask.WriteLine(metricTime + "," + metricLength + "," + name + "," + value);
                }
            }
        }
    }
}
