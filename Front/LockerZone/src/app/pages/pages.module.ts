import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { SharedModule } from '../shared/shared.module';
import { HomeComponent } from './home/home.component';
import { FeedbackComponent } from './feedback/feedback.component';
import { AboutComponent } from './about/about.component';
import { LockerListComponent } from './locker-list/locker-list.component';
import { AddLockerComponent } from './add-locker/add-locker.component';
import { EditLockerComponent } from './edit-locker/edit-locker.component';
import { PoliciesComponent } from './policies/policies.component';
import { RouterModule } from '@angular/router';
import { AdminHomeComponent } from './admin-home/admin-home.component';
import { PayComponent } from './pay/pay.component';



@NgModule({
  declarations: [
    HomeComponent,
    LoginComponent,
    RegisterComponent,
    FeedbackComponent,
    AboutComponent,
    LockerListComponent,
    AddLockerComponent,
    EditLockerComponent,
    PoliciesComponent,
    AdminHomeComponent,
    PayComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    RouterModule
  ]
})
export class PagesModule { }
