import { FileOptions } from "buffer";

export interface Equipments{
    eqpmt_No:string;
    eqpmt_size:number;
    eqpmt_type:string;
    manuf_date:Date;
    equipment_owner:string;
    equipment_photo:File;
    isp_doc:File;
    eqpmt_Id:number;
}

export interface AddEquipInt {
    eqpmt_No: string;
    eqpmt_size: number;
    eqpmt_type: string;
    manuf_date: Date;
    equipment_owner: string;
    equipment_photo: File|null;
    isp_doc: File|null;
}

