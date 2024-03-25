export interface Logistics {
    log1: Logistics[];
    total: number;
    id:number;
    product_Name:string;
    quantity:number;
    ownername:string;
    package_Id:number;
    packed_Date:Date;
    expected_Date:Date;
    price:number;
    delivery_Status:string;
    from_Location:string;
    to_Location:string
}
