import { Component , OnInit} from '@angular/core';
import { ClothserviceService } from '../clothservice.service';
import { Router } from '@angular/router';
import { Cloth } from '../cloth';
import { MatSnackBar } from '@angular/material/snack-bar';
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

 constructor(private clothService:ClothserviceService,private router:Router, private snackBar: MatSnackBar){}
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
      // error:(response)=>
      // {
      //   console.log(response);
      // }
      error: (error) => {
        
        if (error.error.includes('Name')) {
          this.snackBar.open('Name is Required.', 'Close', { duration: 3000 });
        } else if (error.error.includes('Description')) {
          this.snackBar.open('Description is Required.', 'Close', { duration: 3000 });
        }  else if (error.error.includes('Price')) {
          this.snackBar.open('Price is Required.', 'Close', { duration: 3000 });
        } else if (error.error.includes('Color')) {
          this.snackBar.open('Color is Required.', 'Close', { duration: 3000 });
        }  else if (error.error.includes('Size')) {
          this.snackBar.open('Size must be \'S\', \'M\', \'L\', or \'XL\'', 'Close', { duration: 3000 });
        }  else if (error.error.includes('Gender')) {
          this.snackBar.open('Gender must be Male or Female', 'Close', { duration: 3000 });
        } else if (error.error.includes('Count')) {
          this.snackBar.open('Count field is required', 'Close', { duration: 3000 });
        } else if (error.error.includes('Manufacture year must be the current year')) {
          this.snackBar.open('Manufacture year must be the current year', 'Close', { duration: 3000 });
        }
       
      }
    })
  }

}













