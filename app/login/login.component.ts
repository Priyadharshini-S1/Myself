import { Component } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  username: string = '';
  password: string = '';

  constructor(private http: HttpClient) { }

  login() {
    const headers = new HttpHeaders({
      'Authorization': 'Basic ' + btoa(this.username + ':' + this.password)
    });

    this.http.post<any>('https://localhost:7152/api/clothing', {}, { headers })
      .subscribe(
        response => {
          console.log('Login successful');
        },
        error => {
          console.error('Login failed', error);
        }
      );
  }
}
