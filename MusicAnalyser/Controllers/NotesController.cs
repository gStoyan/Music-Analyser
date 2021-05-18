using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using MusicAnalyser.Infrastructure;
using MusicAnalyser.Infrastructure.NotesExtensions;
using MusicAnalyser.Infrastructure.NotesExtensions.Implementations;
using MusicAnalyser.Infrastructure.Session;
using MusicAnalyser.Infrastructure.TextsExtensions;
using MusicAnalyser.Infrastructure.TextsExtensions.Implementations;
using MusicAnalyser.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicAnalyser.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private string path = Path.Combine(Environment.CurrentDirectory, @"../MusicAnalyser.Tests\Extensions\TestFiles\notes.csv");

        private ITextParser textParser;
        private INotesCreator notesCreator;
        public NotesController()
        {
            this.notesCreator = new NotesCreator();
            this.textParser = new TextParser();
        }

        // GET: api/<NotesController>
        [HttpGet]
        public IEnumerable<Note> Get()
        {

            string[] lines = System.IO.File.ReadAllLines(this.path);
            return this.notesCreator.CreateNotes(lines.ToList());
        }

        // GET api/<NotesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<NotesController>
        [HttpPost]
        public ActionResult Post(Text text)
        {
            using (StreamWriter newTask = new StreamWriter(this.path, false))
            {
                newTask.WriteLine(text.Content);
            }
           
            return Ok(text);
        }
    }
}
