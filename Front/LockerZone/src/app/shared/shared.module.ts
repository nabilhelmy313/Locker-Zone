import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { PagesModule } from '../pages/pages.module';
import { MasterLayoutModule } from '../layout/master-layout.module';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BrowserModule } from '@angular/platform-browser';
import { ButtonComponent } from './components/button/button.component';
@NgModule({
  declarations: [
    ButtonComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    MasterLayoutModule,
    BrowserModule,
    BrowserAnimationsModule

  ],
  exports:[
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    ButtonComponent
  ]
})
export class SharedModule { }
