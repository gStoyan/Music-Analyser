
using Melanchall.DryWetMidi.Core;

namespace MusicAnalyser.Infrastructure.MIDIExtensions
{
    public interface IMidiParser
    {
        void ReadFile(MidiFile file);
    }
}
