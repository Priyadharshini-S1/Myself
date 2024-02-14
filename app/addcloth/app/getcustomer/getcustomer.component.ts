import { Component } from '@angular/core';
import { Customers } from '../customers';
import { ClothserviceService } from '../clothservice.service';
@Component({
  selector: 'app-getcustomer',
  templateUrl: './getcustomer.component.html',
  styleUrl: './getcustomer.component.css'
})
export class GetcustomerComponent {
customers:Customers[]=[];
constructor(private clothService:ClothserviceService){

}
ngOnInit(): void {
this.clothService.getCustomers()
.subscribe({
  next:(customers)=>
  {
    this.customers=customers;
  },
  error:(response)=>
  {
    console.log(response);
  }
})


}
}

