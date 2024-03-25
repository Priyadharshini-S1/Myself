import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { BehaviorSubject, Observable } from 'rxjs';
import { Logistics } from './logistics';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
 private baseApi="http://localhost:5184";
 private loggedIn = new BehaviorSubject<boolean>(false);
 
 constructor(private http: HttpClient, public jwtHelper: JwtHelperService) { }

 login(credentials: {username: string, password: string}): Observable<any> {
   const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
   return this.http.post('http://localhost:5184/api/Auth', credentials, { headers, responseType: 'text' });
 }
 logout() {
  
  localStorage.removeItem('token');
  this.loggedIn.next(false);
}

getToken(): string | null {
  return localStorage.getItem('token');
}

isLoggedIn(): Observable<boolean> {
  return this.loggedIn.asObservable();
}


isTokenExpired(): boolean {
  const token = this.getToken();
  return !token || this.jwtHelper.isTokenExpired(token);
}

//  getAll(skip: number):Observable<Logistics>
//  {
//     return this.http.get<Logistics>(this.baseApi+'/api/NewApi/getall?pageIndex=${skip}&pageSize=5');
//  }
getAll(skip:number,sortfield:any,sortorder:number,take:number):Observable<Logistics[]>
{
  if(sortorder==-1){
    return this.http.get<Logistics[]>('http://localhost:5184/api/NewApi?skip='+skip+'&take='+take+'&orderByColumn='+sortfield+'&isAscending=false');
  }
  else{
    return this.http.get<Logistics[]>('http://localhost:5184/api/NewApi?skip='+skip+'&take='+take+'&orderByColumn='+sortfield+'&isAscending=true');
  }
   
}
}
























