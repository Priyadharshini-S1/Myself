// login.component.ts

import { Component } from '@angular/core';
import { AuthService } from '../auth.service';
import { ClothserviceService } from '../clothservice.service';
import { Router } from '@angular/router';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  Username: string = '';
  Password: string = '';
  errorMessage: string = '';
  adminLoginVisible: boolean = false;
  adminErrorMessage: string = '';
  AdminUsername: string = '';
  AdminPassword: string = '';
  constructor(private clothservice:ClothserviceService,private router:Router) { }

  login(): void {
    this.clothservice.login(this.Username, this.Password)
    .subscribe({
      next:(response)=>     
      {
        console.log(response);
        this.router.navigate(['cc']);   
      },
     
      error: (error) => {
        console.error(error);
        if (error && error.error && error.error.message) {
          this.errorMessage = error.error.message;
        } else {
          this.errorMessage = 'Please check your Credentials';
        }
       
      }
    });
  }
  adminlogin(): void {
    if (this.AdminUsername === 'admin' && this.AdminPassword === 'admin') {
      this.router.navigate(['c']);
    } else {
      this.adminErrorMessage = 'Invalid admin credentials';
    }
  }

  toggleLoginType(): void {
    
    this.adminLoginVisible = !this.adminLoginVisible;
  }
}
