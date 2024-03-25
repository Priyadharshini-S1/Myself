import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { homedir } from 'os';
import { HomeComponent } from './components/home/home.component';
import { LazyloadComponent } from './components/lazyload/lazyload.component';


const routes: Routes = [
  
  {
    path:'home', component:HomeComponent
  },
  {
    path:'', redirectTo:'lazylist' ,pathMatch:'full'
  },
  {
    path:'lazylist',component :LazyloadComponent
  }
 
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
