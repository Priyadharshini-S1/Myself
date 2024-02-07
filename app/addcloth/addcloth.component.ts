import { Component , OnInit} from '@angular/core';
import { ClothserviceService } from '../clothservice.service';
import { Router } from '@angular/router';
import { Cloth } from '../cloth';
@Component({
  selector: 'app-addcloth',
  templateUrl: './addcloth.component.html',
  styleUrl: './addcloth.component.css'
})
export class AddclothComponent {
  addclothRequest:Cloth={
   productId:0,
   name:'',
   description:'',
   price:0,
   size:'',
   color:'',
   gender:'',
   inStock:true,
   count:0,
   addedDate:new Date(),
  };

 constructor(private clothService:ClothserviceService,private router:Router){}
 ngOnInit():void{}
 addcloth()
  {
    this.clothService.addclothes(this.addclothRequest)
    .subscribe({
      next:(clothes)=>
      {
        this.router.navigate(['c']);
        console.log(clothes);
      },
      error:(response)=>
      {
        console.log(response);
      }
    })
  }

}













