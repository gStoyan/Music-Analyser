import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {NotesComponent} from '../app/notes/notes.component';
import{ListComponent} from "../app/list/list.component"
import { DrawComponent } from './draw/draw.component';
const routes: Routes = [
  {path: 'List', component: ListComponent},
  {path: 'Draw', component: DrawComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
