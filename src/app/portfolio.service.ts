import { Injectable } from '@angular/core';
import { HttpClient ,HttpHeaders} from '@angular/common/http';
@Injectable({
  providedIn: 'root'
})
export class PortfolioService {
  baseApiUrl:string="http://localhost:4200";
  constructor(private http:HttpClient) { }
}
