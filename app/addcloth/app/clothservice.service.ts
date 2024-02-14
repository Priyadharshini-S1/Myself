import { HttpClient ,HttpHeaders} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Cloth } from './cloth';
import { HttpClientModule } from '@angular/common/http';
import { catchError } from 'rxjs/operators';
import { Customers } from './customers';
@Injectable({
  providedIn: 'root'
})
export class ClothserviceService {
  baseApiUrl:string="https://localhost:7152";
  constructor(private http:HttpClient) {
  }

  getAllclothes():Observable<Cloth[]>{
  return this.http.get<Cloth[]>(this.baseApiUrl+'/api/clothing')
  }
  getAllclothesforcust():Observable<Cloth[]>{
    return this.http.get<Cloth[]>(this.baseApiUrl+'/api/clothing')
    }

  addclothes(addClothRequest:Cloth):Observable<Cloth[]>
  {
   addClothRequest.productId=0;
   return this.http.post<Cloth[]>(this.baseApiUrl+'/api/clothing',addClothRequest);
  }
 

  getClothById(productId:number):Observable<Cloth>
  {
    return this.http.get<Cloth>(this.baseApiUrl+'/api/clothing/'+ productId);
  }

  updateClothDetails(productId:number,updateClothDet:Cloth):Observable<Cloth[]>
  {
    return this.http.put<Cloth[]>(this.baseApiUrl+'/api/clothing/'+productId,updateClothDet);
  }
  deleteClothing(productId:number):Observable<Cloth>
  {
    return this.http.delete<Cloth>(this.baseApiUrl+'/api/clothing/'+productId);
  }
  getCustomers():Observable<Customers[]>{
    return this.http.get<Customers[]>(this.baseApiUrl+'/api/clothing/get')
    }
  addCustomers(addcustomerRequest:Customers):Observable<Customers[]>
  {
    addcustomerRequest.customerId=0;
    return this.http.post<Customers[]>(this.baseApiUrl+'/api/clothing/add',addcustomerRequest);
  }
  login(Username:string,Password:string) : Observable<Cloth>
  {
    return this.http.post<any>(`${this.baseApiUrl}/api/admin/login`, { Username, Password });
  }
}