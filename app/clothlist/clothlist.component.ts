import { Component, OnInit } from '@angular/core';
import { ClothserviceService } from '../clothservice.service';
import { Cloth } from '../cloth';
import { response } from 'express';
import { HttpClient } from '@angular/common/http';
import { Pipe, PipeTransform } from '@angular/core';

@Component({
  selector: 'app-clothlist',
  templateUrl: './clothlist.component.html',
  styleUrl: './clothlist.component.css'
})
export class ClothlistComponent implements OnInit {
  clothes:Cloth[]=[];
  constructor(private clothService:ClothserviceService){

  }
ngOnInit(): void {
  this.clothService.getAllclothes()
  .subscribe({
    next:(clothes)=>
    {
      this.clothes=clothes;
    },
    error:(response)=>
    {
      console.log(response);
    }
  })


}
}
