import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Cart } from './cart';
@Injectable({
  providedIn: 'root'
})
export class CartService {
  baseCarturl:string="https://localhost:7152"
  constructor(private http:HttpClient) { }
  getCart(productId:number,count:number):Observable<Cart>{
    return this.http.get<Cart>(this.baseCarturl+'/api/clothing/cart?productId='+productId+'&count='+count)
  }
}
