import { DatePipe } from "@angular/common";

export interface Cloth {
    productId:number;
    name:string;
    description:string;
    price:number;
    size:string;
    color:string;
    gender:string;
    inStock:boolean;
    count:number;
    addedDate:Date;

}
