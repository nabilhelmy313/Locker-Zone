import { AddLockerComponent } from './pages/add-locker/add-locker.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './pages/login/login.component';
import { RegisterComponent } from './pages/register/register.component';
import { LayoutEnum } from './models/layoutEnum';
import { HomeComponent } from './pages/home/home.component';
import { FeedbackComponent } from './pages/feedback/feedback.component';
import { AboutComponent } from './pages/about/about.component';
import { EditLockerComponent } from './pages/edit-locker/edit-locker.component';
import { PoliciesComponent } from './pages/policies/policies.component';
import { AdminHomeComponent } from './pages/admin-home/admin-home.component';
import { PayComponent } from './pages/pay/pay.component';

const routes: Routes = [
  // { path: '', redirectTo: '/home', pathMatch: 'full',component },
  {path:'',component:PoliciesComponent},
  {path:'home',component:HomeComponent},
  {path:'pay',component:PayComponent},
  {path:'homeAdmin',component:AdminHomeComponent},
  {
    path: 'login',
    component: LoginComponent,
    // data:{
    //   layout:LayoutEnum.Blank
    // },
    // loadComponent: () => import('./pages/login/login.component')
    // .then((m) => m.LoginComponent),
  },
  { path: 'register', component:RegisterComponent },
  { path: 'feedback', component:FeedbackComponent },
  { path: 'about', component:AboutComponent },
  { path: 'addLocker', component:AddLockerComponent },
  { path: 'EditLocker', component:EditLockerComponent,},
  { path: 'polices', component:PoliciesComponent },



];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {

 }
