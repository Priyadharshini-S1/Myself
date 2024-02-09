//import { Component, OnInit } from '@angular/core';
import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';
import {provideNativeDateAdapter} from '@angular/material/core';
import { MatChipsModule} from '@angular/material/chips';
import { MatIconModule } from '@angular/material/icon';
import { MatCardModule} from '@angular/material/card';

@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrl: './add.component.css',
  standalone: true,
  providers: [provideNativeDateAdapter()],
  imports: [MatFormFieldModule, MatInputModule, MatDatepickerModule,MatChipsModule,MatIconModule,MatCardModule],
})

export class AddComponent {
 
}

