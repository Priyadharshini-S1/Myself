// login.component.ts

import { Component } from '@angular/core';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  username: string = '';
  password: string = '';

  constructor(private authService: AuthService) { }

  login(): void {
    this.authService.login(this.username, this.password)
      .subscribe(
        response => {
          console.log("login successful")
        },
        error => {
          console.log("login failed")
        }
      );
  }
}
