import { FileOptions } from "buffer";

export interface Equipments{
    eqpmt_No:string;
    eqpmt_size:string;
    eqpmt_type:string;
    manuf_date:Date;
    equipment_owner:string;
    equipment_photo:File;
    isp_doc:File;
}

export interface AddEquipInt {
    eqpmt_No: string;
    eqpmt_size: string;
    eqpmt_type: string;
    manuf_date: Date;
    equipment_owner: string;
    equipment_photo: File|null;
    isp_doc: File|null;
}

