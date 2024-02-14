import { NgModule } from '@angular/core';
import { BrowserModule, provideClientHydration } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { FormsModule } from '@angular/forms';
import { HttpClient,HttpClientModule } from '@angular/common/http';
import { InputTextModule } from 'primeng/inputtext';
import { PasswordModule } from 'primeng/password';
import { InputTextareaModule } from 'primeng/inputtextarea';
import { CalendarModule } from 'primeng/calendar';
import { DropdownModule } from 'primeng/dropdown';
import { CheckboxModule } from 'primeng/checkbox';
import { ButtonModule } from 'primeng/button';
import { Injectable } from '@angular/core';
import { AddComponent } from './add/add.component';
import { CardModule } from 'primeng/card';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatIconModule} from '@angular/material/icon';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import {MatDatepickerModule} from '@angular/material/datepicker';
import {MatDialog, MatDialogModule} from '@angular/material/dialog';
import { MatNativeDateModule } from '@angular/material/core';
import { MatRadioModule } from '@angular/material/radio';
import { MatSelectModule } from '@angular/material/select';
import {MatChipsModule} from '@angular/material/chips';
import { ClothlistComponent } from './clothlist/clothlist.component';
import { TableModule } from 'primeng/table';
import { AddclothComponent } from './addcloth/addcloth.component';
import { EditclothComponent } from './editcloth/editcloth.component';
import { BrowserAnimationsModule} from '@angular/platform-browser/animations';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatDatepickerToggle } from '@angular/material/datepicker';
import { GetcustomerComponent } from './getcustomer/getcustomer.component';
import { AddcustomerComponent } from './addcustomer/addcustomer.component';
import { CartDetailComponent } from './cart-detail/cart-detail.component';
import { CartcheckComponent } from './cartcheck/cartcheck.component';
import { CclothComponent } from './ccloth/ccloth.component';
import { AdminComponent } from './admin/admin.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    ClothlistComponent,
    AddclothComponent,
    EditclothComponent,
    GetcustomerComponent,
    AddcustomerComponent,
    CartDetailComponent,
    CartcheckComponent,
    CclothComponent,
    AdminComponent

    
  ],
  imports: [
    
   MatDatepickerToggle,
    MatCheckboxModule,
    MatCardModule,
    MatButtonModule,
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    InputTextModule,
    PasswordModule,
    ButtonModule,
    InputTextareaModule,
    CalendarModule,
    DropdownModule,
    CheckboxModule,
    ButtonModule,
    CardModule,
    MatToolbarModule,
    MatIconModule,
    MatFormFieldModule,
    MatInputModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatRadioModule,
    MatSelectModule,
    MatDialogModule,
   MatChipsModule,
   TableModule,
   BrowserAnimationsModule

  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { 

}
