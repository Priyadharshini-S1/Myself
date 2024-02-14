import { Component } from '@angular/core';
import { Cart } from '../cart';
import { ActivatedRoute,Router } from '@angular/router';
import { CartService } from '../cart.service';
import { MatSnackBar } from '@angular/material/snack-bar';
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
  constructor(private route:ActivatedRoute,private cart:CartService,private router:Router, private snackBar: MatSnackBar){}
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
    if(this.carts.productId==0){
      this.snackBar.open('Product Id is Required.', 'Close', { duration: 3000 });
    }
    this.router.navigate(['cart/',this.carts.productId,this.carts.count])
    .catch(error => {
    
      console.error('Navigation Error:', error);
     
      throw new Error('Navigation Error occurred');
    });
  }
}
