
using FluentAssertions;
using MusicAnalyser.Infrastructure;
using MusicAnalyser.Infrastructure.BlockExtensions;
using MusicAnalyser.Infrastructure.BlockExtensions.Implementations;
using MusicAnalyser.Infrastructure.FileExtensions;
using MusicAnalyser.Infrastructure.FileExtensions.Implementations;
using MusicAnalyser.Models;
using MusicAnalyser.Tests.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace MusicAnalyser.Tests.BlocksTests
{
    public class BlockCreatorTests
    {
        private string path = Path.Combine(Environment.CurrentDirectory, @"../../../Extensions\TestFiles\EineKleineNachtmusik.csv");

        private IBlockCreator blockCreator;
        private IFileParser fileParser;

        public BlockCreatorTests()
        {
            this.fileParser = new FileParser();
            this.blockCreator = new BlockCreator();
        }

        [Fact]
        public void BlockCreator_ReturnsBlocks()
        {
            //Arrange
            var note1 = new Note
            {
                Name = "C#",
                Time = 250,
                Tone = 50
            };
            var note2 = new Note
            {
                Name = "Am",
                Time = 240,
                Tone = 47
            };
            var notes = new List<Note>();
            notes.Add(note1);
            notes.Add(note2);
            //Act

            var blocks = this.blockCreator.CreateBlocks(notes);
            //Assert
            blocks.Count.Should().BeGreaterThan(0);
        }
        [Fact]
        public void BlockCreator_WhiteBlock()
        {
            //Arrange
            var note1 = new Note
            {
                Name = "C#",
                Time = 250,
                Tone = 50
            };
            var note2 = new Note
            {
                Name = "Am",
                Time = 240,
                Tone = 47
            };
            var notes = new List<Note>();
            notes.Add(note1);
            notes.Add(note2);
            //Act
            var blocks = this.blockCreator.CreateBlocks(notes);
            //Assert
            blocks[0].Color.Should().Be(Constants.White);
        }
        [Fact]
        public void BlockCreator_DarkBlock()
        {
            //Arrange
            var note1 = new Note
            {
                Name = "C#",
                Time = 250,
                Tone = 50
            };
            var note2 = new Note
            {
                Name = "Am",
                Time = 250,
                Tone = 52
            };
            var notes = new List<Note>();
            notes.Add(note1);
            notes.Add(note2);
            //Act
            var blocks = this.blockCreator.CreateBlocks(notes);
            //Assert
            blocks[0].Color.Should().Be(Constants.DarkGrey);
        }
        [Fact]
        public void BlockCreator_SmokeBlock()
        {
            //Arrange
            var note1 = new Note
            {
                Name = "C#",
                Time = 250,
                Tone = 50
            };
            var note2 = new Note
            {
                Name = "Am",
                Time = 251,
                Tone = 49
            };
            var notes = new List<Note>();
            notes.Add(note1);
            notes.Add(note2);
            //Act
            var blocks = this.blockCreator.CreateBlocks(notes);
            //Assert
            blocks[0].Color.Should().Be(Constants.SmokeGrey);
        }
    }
}
