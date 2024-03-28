import { Component, ElementRef, OnInit } from '@angular/core';
import { Home } from '../home';
import { LoginServiceService } from '../login-service.service';
import { TableLazyLoadEvent } from 'primeng/table';

@Component({
  selector: 'app-lazy-load',
  templateUrl: './lazy-load.component.html',
  styleUrl: './lazy-load.component.css'
})
export class LazyLoadComponent implements OnInit {

  totalRecords:any;
  houses:Home[]=[];
  loadLazyTimeout: any;
  constructor (private lazyService:LoginServiceService,private elementRef: ElementRef)  {}
 
  loading: boolean = true;
 
 
 skip=0;
 take=5;
  selectAll: boolean = false;
 
  selectedCustomers!: Home[];
 

  idFilter: any= '';
  titleFilter: any = '';
  priceFilter: any = '';
  authorFilter: any = '';
  editionFilter: any = '';
  globalFilter:any='';
 
  ngOnInit() {
    this.lazyService.getcount().subscribe(
      (response) => {
          this.totalRecords=response;
      }
    );
  }
  onIDFilterChange(event: any) {
    const value = (event.target as HTMLInputElement)?.value;
    if (value !== undefined) {
        this.idFilter = value;
        const event: TableLazyLoadEvent = {
            first: 0,
            sortField: '',
            sortOrder: 1
        };
        this.getUsers(event);
    }
}
 
onTitleFilterChange(event: any) {
  const value = (event.target as HTMLInputElement)?.value;
  if (value !== undefined) {
      this.titleFilter = value;
      const event: TableLazyLoadEvent = {
          first: 0,
          sortField: '',
          sortOrder: 1
      };
      this.getUsers(event);
  }
}
 
onPriceFilterChange(event: any) {
  const value = (event.target as HTMLInputElement)?.value;
  if (value !== undefined) {
      this.priceFilter = value;
      const event: TableLazyLoadEvent = {
          first: 0,
          sortField: '',
          sortOrder: 1
      };
      this.getUsers(event);
  }
}
 
onAuthorFilterChange(event: any) {
  const value = (event.target as HTMLInputElement)?.value;
  if (value !== undefined) {
      this.authorFilter = value;
      const event: TableLazyLoadEvent = {
          first: 0,
          sortField: '',
          sortOrder: 1
      };
      this.getUsers(event);
  }
}
onEditionFilterChange(event: any) {
  const value = (event.target as HTMLInputElement)?.value;
  if (value !== undefined) {
      this.editionFilter = value;
      const event: TableLazyLoadEvent = {
          first: 0,
          sortField: '',
          sortOrder: 1
      };
      this.getUsers(event);
  }
}
 
  getUsers(event: TableLazyLoadEvent) {
    this.loading = true;
    setTimeout(() => {
    this. lazyService.getallProducts(event.first || 0, event.sortField, event.sortOrder||0, this.take, this.idFilter, this.titleFilter, this.priceFilter, this.authorFilter, this.editionFilter, this.globalFilter).subscribe(
        (response) => {
          this.houses = response;
          this.loading=false;
        }
      );
    }, 1000);
  }
  filterUser(){
   
    const event: TableLazyLoadEvent = {
      first: 0,
      sortField: '',
      sortOrder: 1
    };
   
    this.getUsers(event);
  }

  clearFilters() {
 
    this.idFilter = '';
    this.titleFilter = '';
    this.priceFilter = '';
    this.authorFilter = '';
    this.editionFilter='';
    this.globalFilter = '';
 
 
    const inputFields = this.elementRef.nativeElement.querySelectorAll('input[type="text"]');
    inputFields.forEach((input: HTMLInputElement) => {
      input.value = '';
    });
 
   
    const event: TableLazyLoadEvent = {
      first: 0,
      sortField: '',
      sortOrder: 1
    };
  this.getUsers(event);
  }
  // getTransact(){
  //   this.lazyService.getAllHouses()
  //   .subscribe({
  //     next:(houses)=>
  //     {
  //       console.log(houses);
  //       this.houses=houses;
  //     },
  //     error:(response)=>
  //     {
  //       console.log(response);
  //     }
  //   })
  // }

  // ngOnInit (): void{this.loading=true}


  // loadCustomers() {
  //   this.loading = true;
 
  //   setTimeout(() => {
  //       this.getTransact();
  //       this.loading=false;
  //   }, 1000);

  // }
//   onLazyLoad(event) {
//     this.loading = true;

//     if (this.loadLazyTimeout) {
//         clearTimeout(this.loadLazyTimeout);
//     }

//     //imitate delay of a backend call
//     this.loadLazyTimeout = setTimeout(() => {
//         const { first, last } = event;
//         const items = [...this.items];

//         for (let i = first; i < last; i++) {
//             items[i] = { label: `Item #${i}`, value: i };
//         }

//         this.items = items;
//         this.loading = false;
//     }, Math.random() * 1000 + 250);
// }
  
}
