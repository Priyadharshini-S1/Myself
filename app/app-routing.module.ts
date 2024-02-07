import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { AddComponent } from './add/add.component';
import { ClothlistComponent } from './clothlist/clothlist.component';
import { AddclothComponent } from './addcloth/addcloth.component';
import { EditclothComponent } from './editcloth/editcloth.component';

const routes: Routes = [
  {path:'',component:LoginComponent},
  {path:'c',component:ClothlistComponent},
  {path:'add',component:AddclothComponent},
  {path:'edit/:productId',component:EditclothComponent},
  {path:'delete/:productId',component:EditclothComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
