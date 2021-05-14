import { Component, OnInit } from '@angular/core';

import{FormGroup,FormControl} from "@angular/forms";
import{NotesModel} from "../models/NotesModel"
import {ActivatedRoute} from '@angular/router'
import {NotesService} from '../services/notes.service'

@Component({
  selector: 'app-notes',
  templateUrl: './notes.component.html',
  styleUrls: ['./notes.component.css']
})
export class NotesComponent implements OnInit {
  model: NotesModel
  isClicked = false;
  notesForm = new FormGroup({
    'notes': new FormControl('')
  })
  constructor(private route: ActivatedRoute, private noteServices: NotesService) { }

  ngOnInit(): void {
    
  }
  
  create(){    
    this.isClicked = true;
    this.model = new NotesModel(this.notesForm.get('notes').value)  
    this.noteServices.PostNotesModel(this.model)
  }
}
