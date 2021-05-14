using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicAnalyser.Infrastructure.FileExtensions;
using MusicAnalyser.Infrastructure.FileExtensions.Implementations;
using MusicAnalyser.Tests.Extensions;
using System;
using System.IO;
using System.Linq;
using Xunit;

namespace MusicAnalyser.Tests.FileTests
{
    public class FileParserTests
    {
        private string path = Path.Combine(Environment.CurrentDirectory, @"../../../Extensions\TestFiles\EineKleineNachtmusik.csv");

        private IFileParser fileParser;

        public FileParserTests()
        {
            this.fileParser = new FileParser();
        }

        [Fact]
        public void FileParser_ReturnsNotes()
        {
            //Arrange
            var fileReader = new FileReader();
            //Act
            var lines = fileReader.ReadFile(this.path);
            var notes = fileParser.ParseCsv(lines);
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
