import { Component, OnInit } from '@angular/core';
import { ClothserviceService } from '../clothservice.service';
import { ActivatedRoute, Router } from '@angular/router';
import { response } from 'express';
import { Cloth } from '../cloth';
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

  constructor(private clothService:ClothserviceService,private router:Router,private route:ActivatedRoute){}

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
     this.clothService.updateClothDetails(Number(this.editClothDetails.productId),this.editClothDetails)
     .subscribe({
       next:(response)=>
       {
         this.router.navigate(['c']);
         console.log(response);
       },
       error:(response)=>
       {
         console.log(response);
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
       },
       error:(response)=>
       {
         console.log(response);
       }
     });
   }
 
 
 
 
 
 
 
 }