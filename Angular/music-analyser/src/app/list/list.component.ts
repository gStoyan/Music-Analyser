import { Component, OnInit } from '@angular/core';

import {ActivatedRoute} from '@angular/router'
import {NotesService} from '../services/notes.service'
@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit {

  public Notes 
  constructor(private route: ActivatedRoute, private noteServices: NotesService) { }

  ngOnInit(): void {   
    this.noteServices.GetNotes()
    .subscribe(data=>{
      this.Notes = data
      console.log(data)
    })
  }
}
