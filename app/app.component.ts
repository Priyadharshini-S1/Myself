import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { AddComponent } from './add/add.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'clothings';
  constructor(private _dialog: MatDialog){}

  openAdd(){
    this._dialog.open(AddComponent)
  }
}
