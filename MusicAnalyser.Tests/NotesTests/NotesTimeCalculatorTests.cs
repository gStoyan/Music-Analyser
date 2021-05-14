using FluentAssertions;
using MusicAnalyser.Infrastructure.NotesExtensions;
using MusicAnalyser.Infrastructure.NotesExtensions.Implementations;
using System.ComponentModel;
using Xunit;

namespace MusicAnalyser.Tests.NotesTests
{
    public class NotesTimeCalculatorTests
    {
        private INotesTimeCalculator notesTimeCalculator;

        public NotesTimeCalculatorTests()
        {
            this.notesTimeCalculator = new NotesTimeCalculator();
        }

        [Fact]
        [Description("Get miliseonds from string Hour:Minute:Second:Millisec")]

        public void GetMilisecondsFromString()
        {
            //Arrange
            string text = "00:00:00:847";
            //Act
            int miliseconds = this.notesTimeCalculator.ConvertToMiliSeconds(text);
            //Assert
            miliseconds.Should().Be(847);
        }
    }
}
