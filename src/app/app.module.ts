import { NgModule } from '@angular/core';
import { BrowserModule, provideClientHydration } from '@angular/platform-browser';
import { TableModule } from 'primeng/table';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ButtonModule } from 'primeng/button';
import { DropdownModule } from 'primeng/dropdown';
import { TagModule } from 'primeng/tag';
import { FormsModule } from '@angular/forms';
import {DialogModule} from 'primeng/dialog';
import { HttpClientModule } from "@angular/common/http";
import { FormGroup } from '@angular/forms';
import { StyleClassModule } from 'primeng/styleclass';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RouterModule } from '@angular/router';
import { CalendarModule } from 'primeng/calendar';
import { FileUploadModule } from 'primeng/fileupload';
import { ToastModule } from 'primeng/toast';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { NextPageComponent } from './next-page/next-page.component';
import { EquipmentPhotoDialogComponent } from './equipment-photo-dialog/equipment-photo-dialog.component';
import { MatDialogModule } from '@angular/material/dialog';
import { MatIconModule } from '@angular/material/icon';
@NgModule({
  declarations: [
    AppComponent,
    NextPageComponent,
    EquipmentPhotoDialogComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    TableModule,
    ButtonModule,
    DropdownModule,
    TagModule ,
    FormsModule,
    BrowserAnimationsModule,
    ButtonModule,
    DialogModule,
    StyleClassModule,
    HttpClientModule,
    CalendarModule,
    FileUploadModule,
    ToastModule,
    MatDialogModule,
    MatIconModule
  
  ],
  providers: [
    provideClientHydration(),
    provideAnimationsAsync()
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
