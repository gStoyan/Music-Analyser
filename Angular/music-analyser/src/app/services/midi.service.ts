import {HttpClient, HttpClientModule,HttpHeaders} from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class MidiService {
  
 // path = '/api/';
 private port = 44371;
 private path = 'https://localhost:'+this.port+'/api/';
 private midi = "Midi"
 constructor(private http: HttpClient) { }


  PostMidiFile(file: any){
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type':  'application/json',
        Authorization: 'my-auth-token'
      })
    };
    let body = JSON.stringify(file)
    return this.http.post(this.path + this.midi, body,httpOptions).subscribe();
  
  }
}
