import { Component } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ClothserviceService } from '../clothservice.service';
import { Router } from '@angular/router';
import { Customers } from '../customers';
@Component({
  selector: 'app-addcustomer',
  templateUrl: './addcustomer.component.html',
  styleUrl: './addcustomer.component.css'
})
export class AddcustomerComponent {
addcustomerRequest:Customers={
  customerId:0,
  customerName:'',
  customerAge: 0,
  productId:0,
  count:0
};
constructor(private clothService:ClothserviceService,private router:Router, private snackBar: MatSnackBar){}
 ngOnInit():void{}
 addcustomer()
  {
    this.clothService.addCustomers(this.addcustomerRequest)
    .subscribe({
      next:(customer)=>
      {
        this.router.navigate(['customer']);
        console.log(customer);
      },
      error: (error) => {
        console.log(error);
}

})
}
}
