import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './pages/login/login.component';
import { RegisterComponent } from './pages/register/register.component';
import { LayoutEnum } from './models/layoutEnum';
import { HomeComponent } from './pages/home/home.component';

const routes: Routes = [
  // { path: '', redirectTo: '/home', pathMatch: 'full',component },
  {path:'home',component:HomeComponent},
  {
    path: 'login',
    component: LoginComponent,
    // data:{
    //   layout:LayoutEnum.Blank
    // },
    // loadComponent: () => import('./pages/login/login.component')
    // .then((m) => m.LoginComponent),
  },
  { path: 'register', component:RegisterComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {

 }
