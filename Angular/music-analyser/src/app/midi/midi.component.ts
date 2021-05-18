import { Component, OnInit,ViewChild  } from '@angular/core';
import {HttpClient, HttpParams, HttpRequest, HttpEvent, HttpEventType, HttpResponse} from '@angular/common/http';
import{MidiService} from "../services/midi.service";
@Component({
  selector: 'app-midi',
  templateUrl: './midi.component.html',
  styleUrls: ['./midi.component.css']
})
export class MidiComponent implements OnInit {

  private port = 44371;
  @ViewChild('fileInput') fileInput;
  constructor(private midiServices: MidiService) { }
  
  public upload() {
    const fileBrowser = this.fileInput.nativeElement;
    if (fileBrowser.files && fileBrowser.files[0]) {
      const formData = new FormData();
      formData.append('files', fileBrowser.files[0]);
      const xhr = new XMLHttpRequest();
      xhr.open('POST', 'https://localhost:'+this.port+'/api/midi', true);
      xhr.onload = function () {
        if (this['status'] === 200) {
            const responseText = this['responseText'];
            const files = JSON.parse(responseText);
            //todo: emit event
        } else {
          //todo: error handling
        }
      };
      xhr.send(formData);
    }
  }
  ngOnInit(): void {  
  }
}
