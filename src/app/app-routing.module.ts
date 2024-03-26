import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { NextPageComponent } from './next-page/next-page.component';

const routes: Routes = [
  {path: 'app',component:AppComponent},
  {path: 'next-page',component:NextPageComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
