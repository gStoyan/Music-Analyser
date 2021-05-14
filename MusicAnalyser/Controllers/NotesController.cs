using Microsoft.AspNetCore.Mvc;
using MusicAnalyser.Infrastructure.NotesExtensions;
using MusicAnalyser.Infrastructure.NotesExtensions.Implementations;
using MusicAnalyser.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicAnalyser.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private string path = Path.Combine(Environment.CurrentDirectory, @"../MusicAnalyser.Tests\Extensions\TestFiles\test.csv");

        private INotesCreator fileParser;
        public NotesController()
        {
            this.fileParser = new NotesCreator();
        }

        // GET: api/<NotesController>
        [HttpGet]
        public IEnumerable<Note> Get()
        {
            string[] lines = System.IO.File.ReadAllLines(this.path);
            return fileParser.ParseCsv(lines.ToList());
        }

        // GET api/<NotesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<NotesController>
        [HttpPost]
        public ActionResult Post(Notes text)
        {
            using (StreamWriter newTask = new StreamWriter(this.path, false))
            {
                newTask.WriteLine(text.Text);
            }
            return Ok(text);
        }

        // PUT api/<NotesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<NotesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
