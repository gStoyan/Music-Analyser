using FluentAssertions;
using MusicAnalyser.Infrastructure.NotesExtensions;
using MusicAnalyser.Infrastructure.NotesExtensions.Implementations;
using MusicAnalyser.Models;
using System.Collections.Generic;
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
        [Fact]
        public void GetNotes_ReturnsNotes()
        {
            //Arrange
            var noteNames = new List<string>() { "39-C#", "27-Am" };
            var notesOnTime = new List<int>() { 250, 300 };
            var notesOffTime = new List<int>() { 300, 350 };
            //Act
            var notes = this.notesTimeCalculator.GetNotesWithTime(noteNames, notesOnTime, notesOffTime);
            //Assert
            notes.Count.Should().BeGreaterThan(0);

        }
    }
}
