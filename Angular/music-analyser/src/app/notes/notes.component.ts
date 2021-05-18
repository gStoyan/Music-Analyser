import { Component, OnInit } from '@angular/core';

import{FormGroup,FormControl} from "@angular/forms";
import{Text} from "../models/TextModel"
import {ActivatedRoute} from '@angular/router'
import {NotesService} from '../services/notes.service'

@Component({
  selector: 'app-notes',
  templateUrl: './notes.component.html',
  styleUrls: ['./notes.component.css']
})
export class NotesComponent implements OnInit {
  model: Text
  isClicked = false;
  notesForm = new FormGroup({
    'notes': new FormControl('')
  })
  constructor(private route: ActivatedRoute, private noteServices: NotesService) { }

  ngOnInit(): void {
    
  }  
  Clicked(){    
    this.isClicked = true;
  }
}
