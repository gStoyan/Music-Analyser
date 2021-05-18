using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Interaction;
using System;
using System.Collections.Generic;
using System.IO;

namespace Music.Analyser.MIDIReader
{
    public class MIDIParser
    {
        private string midiPath = Path.Combine(Environment.CurrentDirectory, @"../MusicAnalyser.Tests\Extensions\TestFiles\shapeMain.mid");
        private string txtPath = Path.Combine(Environment.CurrentDirectory, @"../MusicAnalyser.Tests\Extensions\TestFiles\test.text");

        public void Run()
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
                }
            }
        }
    }
}
