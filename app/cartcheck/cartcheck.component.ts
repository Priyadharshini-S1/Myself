import { Component } from '@angular/core';
import { Cart } from '../cart';
import { ActivatedRoute,Router } from '@angular/router';
import { CartService } from '../cart.service';
@Component({
  selector: 'app-cartcheck',
  templateUrl: './cartcheck.component.html',
  styleUrl: './cartcheck.component.css'
})
export class CartcheckComponent {
  carts:Cart={
    productId: 0,
    productName: '',
    count: 0,
    totalprice: 0
  };
  constructor(private route:ActivatedRoute,private cart:CartService,private router:Router){}
  fetchStock(productId:number,count:number)
  {
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
                 this.carts=response;
              }
 
            })
          }
        }
      }
    )
  }
  sample()
  {
    this.router.navigate(['cart/',this.carts.productId,this.carts.count]);
  }
}
