import { Component } from '@angular/core';
import { Logistics } from '../../logistics';
import { AuthService } from '../../auth.service';
import { TableLazyLoadEvent } from 'primeng/table';

@Component({
  selector: 'app-lazyload',
  templateUrl: './lazyload.component.html',
  styleUrl: './lazyload.component.css'
})
export class LazyloadComponent {
  log1!:Logistics[];
  totalRecords = 10;
  loading = true;
  skip=0;
  take=8;
  selectAll: boolean = false;
  selectedCustomers!: Logistics[];


  constructor(private logService:AuthService){}

 
 

 
 

 
  ngOnInit() {
   
  }
 
 
  getUsers(event:TableLazyLoadEvent) {
    this.loading = true;
    setTimeout(() => {
    this.logService.getAll(event.first || 0,event.sortField,event.sortOrder||0,this.take).subscribe(
        (response) => {
          this.log1 = response;
          console.log(response);
          this.loading=false;
        }
      );
    }, 1000);
  }
 

}
