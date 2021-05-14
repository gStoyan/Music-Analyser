import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class BlocksService {

  private port = 44371;
  private path = 'https://localhost:'+this.port+'/api/';
  private block = "Block"
  constructor(private http: HttpClient) { }

  GetBlocks(){
    return this.http.get(this.path + this.block);
  }
  
}
