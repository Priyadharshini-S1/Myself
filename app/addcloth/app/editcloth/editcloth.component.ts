import { Component, OnInit } from '@angular/core';
import { ClothserviceService } from '../clothservice.service';
import { ActivatedRoute, Router } from '@angular/router';
import { DatePipe } from '@angular/common';
import { response } from 'express';
import { Cloth } from '../cloth';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { MatInputModule} from '@angular/material/input';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-editcloth',
  templateUrl: './editcloth.component.html',
  styleUrl: './editcloth.component.css'
})
export class EditclothComponent implements OnInit {

  editClothDetails:Cloth={
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

  constructor(private clothService:ClothserviceService,private router:Router,private route:ActivatedRoute, private snackBar: MatSnackBar){}

  setUtcDate(date: Date): Date {
    return new Date(Date.UTC(date.getFullYear(), date.getMonth(), date.getDate(), 
                             date.getHours(), date.getMinutes(), date.getSeconds()));
  }

  handleSubmit() {
    const utcDate = this.setUtcDate(this.editClothDetails.addedDate);
  }

  ngOnInit(): void {
    this.route.paramMap.subscribe({
     next:(params)=>
     {
      const productId=params.get('productId');
       if(productId)
       {
         this.clothService.getClothById(Number(productId))
         .subscribe({
           next:(response)=>{
             this.editClothDetails=response;
           }
         })
       }
       
     }
    })
   }
 
   updateCloth()
   {
    if (!this.editClothDetails.gender) {
      this.snackBar.open('Gender is required.', 'Close', { duration: 3000 });
      return;
  }
  if (!this.editClothDetails.price) {
    this.snackBar.open('Price is required.', 'Close', { duration: 3000 });
    return; 
}
     this.clothService.updateClothDetails(Number(this.editClothDetails.productId),this.editClothDetails)
     .subscribe({
       next:(response)=>
       {
         this.router.navigate(['c']);
         this.snackBar.open('Clothing details updated successfully', 'Close', { duration: 3000 });
         console.log(response);
       },
      //  error:(response)=>
      //  {
      //    console.log(response);
      //  }
      error: (error) => {
        
        if (error.error.includes('All')) {
          this.snackBar.open('Name,Description,Price,count fields are Required', 'Close', { duration: 3000 });
        } else if (error.error.includes('Size')) {
          this.snackBar.open('Size must be \'S\', \'M\', \'L\', or \'XL\'', 'Close', { duration: 3000 });
        }  else if (error.error.includes('Gender')) {
          this.snackBar.open('Gender must be Male or Female', 'Close', { duration: 3000 });
        } else if (error.error.includes('Count')) {
          this.snackBar.open('Count field is required', 'Close', { duration: 3000 });
        } else if (error.error.includes('Manufacture year must be the current year')) {
          this.snackBar.open('Manufacture year must be the current year', 'Close', { duration: 3000 });
        }
       
      }
     });
   }
 
   deleteCloth(productId:number)
   {
     this.clothService.deleteClothing(productId)
     .subscribe({
       next:(response)=>
       {
         this.router.navigate(['c']);
         this.snackBar.open('Clothing deleted successfully', 'Close', { duration: 3000 });
        
       },
       error:(response)=>
       {
         console.log(response);
       }
     });
   }

 
 }