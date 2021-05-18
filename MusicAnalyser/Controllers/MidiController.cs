
using Melanchall.DryWetMidi.Core;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicAnalyser.Infrastructure.MIDIExtensions;
using MusicAnalyser.Infrastructure.MIDIExtensions.Implementations;
using System;
using System.Collections.Generic;
using System.IO;

namespace MusicAnalyser.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MidiController : ControllerBase
    {
        private string path = Path.Combine(Environment.CurrentDirectory, @"../MusicAnalyser.Tests\Extensions\TestFiles\song.mid");
        private readonly IWebHostEnvironment hostingEnvironment;
        private IMidiParser midiParser;

        public MidiController(IWebHostEnvironment environment)
        {
            this.midiParser = new MidiParser();
            hostingEnvironment = environment;
        }

        // POST api/<MidiController>
        [HttpPost]
        [Consumes("multipart/form-data")]
        public ActionResult Post()
        {
            var files = Request.Form.Files;
            var strigValue = Request.Form.Keys;
            if (files != null)
            {
                var file = files[0];
                using (Stream fileStream = new FileStream(path, FileMode.Create))
                {
                     file.CopyTo(fileStream);
                }

                //to do : Save uniqueFileName  to your db table   
            }
            this.midiParser.CreateTxt();
            // to do  : Return something
            return RedirectToAction("Index", "Home");
        }
    }
}
