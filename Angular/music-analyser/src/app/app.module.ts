import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import{FormsModule,ReactiveFormsModule} from "@angular/forms";
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NotesComponent } from './notes/notes.component';
import {DataViewModule} from 'primeng/dataview';
import {ButtonModule} from 'primeng/button';
import {OrderListModule} from 'primeng/orderlist';
import {InputTextModule} from 'primeng/inputtext';
import {InputTextareaModule} from 'primeng/inputtextarea';
import { ListComponent } from './list/list.component';
import { DrawComponent } from './draw/draw.component';
import { MidiComponent } from './midi/midi.component';

@NgModule({
  declarations: [
    AppComponent,
    NotesComponent,
    ListComponent,
    DrawComponent,
    MidiComponent
  ],
  imports: [
    FormsModule,
    ReactiveFormsModule,
    InputTextareaModule,
    InputTextModule,
    OrderListModule,
    DataViewModule,
    HttpClientModule,
    BrowserModule,
    AppRoutingModule,
    ButtonModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
