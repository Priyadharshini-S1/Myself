import { Component } from '@angular/core';
import { LoginServiceService } from '../login-service.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {

  credentials = { username: '', password: '' };
 
  constructor(private authService: LoginServiceService) {}

  login() {
    this.authService.login(this.credentials).subscribe({
      next: (response) => {
        alert("login Success") 
      },
      error: (error) => {

        alert('Invalid username or password');
      
      }
    });
  }

}

