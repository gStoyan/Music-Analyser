using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicAnalyser.Infrastructure.NotesExtensions;
using MusicAnalyser.Infrastructure.NotesExtensions.Implementations;
using MusicAnalyser.Tests.Extensions;
using System;
using System.IO;
using System.Linq;
using Xunit;

namespace MusicAnalyser.Tests.NotesTests
{
    public class NotesCreatorTests
    {
        private string path = Path.Combine(Environment.CurrentDirectory, @"../../../Extensions\TestFiles\EineKleineNachtmusik.csv");

        private INotesCreator notesCreator;

        public NotesCreatorTests()
        {
            this.notesCreator = new NotesCreator();
        }

        [Fact]
        public void NotesCreator_ReturnsNotes()
        {
            //Arrange
            var fileReader = new FileReader();
            //Act
            var lines = fileReader.ReadFile(this.path);
            var notes = notesCreator.CreateNotes(lines);
            //Assert           
            notes.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void ReadTestFile_ReturnsRightNumberOfLines()
        {
            //Arrange
            var fileReader = new FileReader();
            //Act
            var lines = fileReader.ReadFile(this.path);
            //Assert
            lines.Count.Should().BeGreaterThan(0);
        }
    }
}
