import { Component, OnInit } from '@angular/core';
import { Cart } from '../cart';
import { ActivatedRoute } from '@angular/router';
import { CartService } from '../cart.service';
@Component({
  selector: 'app-cart-detail',
  templateUrl: './cart-detail.component.html',
  styleUrl: './cart-detail.component.css'
})
export class CartDetailComponent implements OnInit {
  carting:any
  constructor(private route:ActivatedRoute,private cart:CartService){}
  ngOnInit(): void {
    this.route.paramMap.subscribe(
      {
        next:(paramas)=>
        {
          const productId=paramas.get('productId');
          const count=paramas.get('count');
          if(productId){
            this.cart.getCart(Number(productId),Number(count)).subscribe({
              next:(response)=>
              {
                 this.carting=response;
              }
            })
          }
        }
      }
    )
  }
}
