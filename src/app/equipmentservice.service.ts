import { Injectable } from '@angular/core';
import { HttpClient ,HttpHeaders} from '@angular/common/http';
import { Equipments } from './Equipments';
import { Observable } from 'rxjs';
import { AddEquipInt } from './Equipments';
@Injectable({
  providedIn: 'root'
})
export class EquipmentserviceService {
  baseApiUrl:string="http://localhost:5127";
  constructor(private http:HttpClient) {
  }
  getAllequipments():Observable<Equipments[]>{
    return this.http.get<Equipments[]>(this.baseApiUrl+'/api/equipment')
    }
  
  // addequipments(addeqpmtRequests:Equipments):Observable<Equipments[]>
  //   {
  //     return this.http.post<Equipments[]>(this.baseApiUrl+'/api/equipment',addeqpmtRequests);
  //   }
  // addequipments(addeqpmtRequests: AddEquipInt): Observable<AddEquipInt[]> {
  //   return this.http.post<AddEquipInt[]>(this.baseApiUrl+'/api/equipment', addeqpmtRequests);
  // }
  addequipments(addeqpmtRequests:AddEquipInt):Observable<any>
  {
    const formData = new FormData();
    formData.append('eqpmt_No', addeqpmtRequests.eqpmt_No);
    formData.append('eqpmt_size', addeqpmtRequests.eqpmt_size);
    formData.append('eqpmt_type', addeqpmtRequests.eqpmt_type);
    formData.append('manuf_date', addeqpmtRequests.manuf_date.toISOString());
    formData.append('equipment_owner', addeqpmtRequests.equipment_owner);
    if (addeqpmtRequests.equipment_photo) {
      formData.append('equipment_photo', addeqpmtRequests.equipment_photo);
    }
    if (addeqpmtRequests.isp_doc) {
      formData.append('isp_doc', addeqpmtRequests.isp_doc);
    }
    
    return this.http.post<AddEquipInt[]>(this.baseApiUrl+'/api/equipment',formData);
  }

  // getEquipmentByNo(eqpmt_No:string):Observable<Equipments>
  //   {
  //     return this.http.get<Equipments>(this.baseApiUrl+'/api/equipment/'+ eqpmt_No);
  //   }
  getEquipmentByNo(eqpmt_No:string):Observable<any>
  {
    return this.http.get<Equipments>(this.baseApiUrl+'/api/equipment/'+ eqpmt_No);
  }
  // updateEquipmentDetails(eqpmt_No:string,updateEquipDet:Equipments):Observable<Equipments[]>
  //   {
  //     return this.http.put<Equipments[]>(this.baseApiUrl+'/api/equipment/'+eqpmt_No,updateEquipDet);
  //   }

  updateEquipmentDetails(eqpmt_No:string,addeqpmtRequest:Equipments):Observable<any>
    {
      const formData = new FormData();
      formData.append('eqpmt_No', addeqpmtRequest.eqpmt_No);
      formData.append('eqpmt_size', addeqpmtRequest.eqpmt_size);
      formData.append('eqpmt_type', addeqpmtRequest.eqpmt_type);
      formData.append('equipment_owner', addeqpmtRequest.equipment_owner);
    if (addeqpmtRequest.equipment_photo) {
      formData.append('equipment_photo', addeqpmtRequest.equipment_photo);
    }
    if (addeqpmtRequest.isp_doc) {
      formData.append('isp_doc', addeqpmtRequest.isp_doc);
    }
      return this.http.put<AddEquipInt[]>(this.baseApiUrl+'/api/equipment/'+eqpmt_No,formData);
    }
  deleteEquipments(eqpmt_No:string):Observable<Equipments>
    {
      return this.http.delete<Equipments>(this.baseApiUrl+'/api/equipment/'+eqpmt_No);
    }
  uploadFormData(formData: FormData) {
      return this.http.post<any>(this.baseApiUrl+'/api/equipment/', formData);
    }
}
