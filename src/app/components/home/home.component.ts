import { Component } from '@angular/core';
import { AuthService } from '../../auth.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {

    credentials = { username: '', password: '' };
  
   constructor(private authService: AuthService) {}
  
   login() {
     this.authService.login(this.credentials).subscribe({
       next: (response) => {
         alert("login Success")
         console.log('Response from server:', response);
       },
       error: (error) => {
  
         alert('Invalid username or password');
        
       }
     });
   }
  
 }
  

