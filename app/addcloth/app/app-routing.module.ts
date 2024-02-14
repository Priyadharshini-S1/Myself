import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { AddComponent } from './add/add.component';
import { ClothlistComponent } from './clothlist/clothlist.component';
import { AddclothComponent } from './addcloth/addcloth.component';
import { EditclothComponent } from './editcloth/editcloth.component';
import { GetcustomerComponent } from './getcustomer/getcustomer.component';
import { AddcustomerComponent } from './addcustomer/addcustomer.component';
import { CartcheckComponent } from './cartcheck/cartcheck.component';
import { CartDetailComponent } from './cart-detail/cart-detail.component';
import { CclothComponent } from './ccloth/ccloth.component';


const routes: Routes = [
  {path:'',component:LoginComponent},
  {path:'c',component:ClothlistComponent},
  {path:'cc',component:CclothComponent},
  {path:'add',component:AddclothComponent},
  {path:'edit/:productId',component:EditclothComponent},
  {path:'delete/:productId',component:EditclothComponent},
  {path:'customer',component:GetcustomerComponent},
  {path:'addcustomer',component:AddcustomerComponent},
  {path:'addcart',component:CartcheckComponent},
  {path:'cart/:productId/:count',component:CartDetailComponent},
  {path: 'login',component:LoginComponent},
  {path:'',redirectTo:'login',pathMatch:"full"}
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
