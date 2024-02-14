import { Component } from '@angular/core';
import { ClothserviceService } from '../clothservice.service';
import { Cloth } from '../cloth';
import { OnInit } from '@angular/core';

@Component({
  selector: 'app-ccloth',
  templateUrl: './ccloth.component.html',
  styleUrl: './ccloth.component.css'
})
export class CclothComponent implements OnInit  {
  clothes:Cloth[]=[];
  constructor(private clothService:ClothserviceService){

  }
ngOnInit(): void {
  this.clothService.getAllclothesforcust()
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
