import { Injectable } from '@angular/core';
import {HttpClient, HttpClientModule,HttpHeaders} from '@angular/common/http';
import { NotesModel } from '../models/NotesModel';


@Injectable({
  providedIn: 'root'
})
export class NotesService {

  private port = 44371;
  private path = 'https://localhost:'+this.port+'/api/';
  private notes = "Notes"
  constructor(private http: HttpClient) { }

  GetNotes(){
    return this.http.get(this.path + this.notes);
  }
  PostNotesModel(notes: NotesModel){
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type':  'application/json',
        Authorization: 'my-auth-token'
      })
    };
    let body = JSON.stringify(notes)
    return this.http.post(this.path + this.notes, body,httpOptions).subscribe();
    
  }
}
