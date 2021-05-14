
using Microsoft.AspNetCore.Mvc;
using MusicAnalyser.Infrastructure.BlockExtensions;
using MusicAnalyser.Infrastructure.BlockExtensions.Implementations;
using MusicAnalyser.Infrastructure.FileExtensions;
using MusicAnalyser.Infrastructure.FileExtensions.Implementations;
using MusicAnalyser.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MusicAnalyser.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlockController : ControllerBase
    {
        private string path = Path.Combine(Environment.CurrentDirectory, @"../MusicAnalyser.Tests\Extensions\TestFiles\test.csv");

        private IFileParser fileParser;
        private IBlockCreator blockCreator;
        public BlockController()
        {
            this.fileParser = new FileParser();
            this.blockCreator = new BlockCreator();
        }

        [HttpGet]
        public IEnumerable<Block> Get()
        {
            string[] lines = System.IO.File.ReadAllLines(this.path);
            var notes = fileParser.ParseCsv(lines.ToList());

            return this.blockCreator.CreateBlocks(notes);
        }
    }
}
