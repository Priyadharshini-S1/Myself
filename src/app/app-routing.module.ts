import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LazyLoadComponent } from './lazy-load/lazy-load.component';

const routes: Routes = [

  
{path:'', component:LazyLoadComponent}

];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {

  
 }
