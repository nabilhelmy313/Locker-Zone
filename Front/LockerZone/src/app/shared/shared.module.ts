import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BrowserModule } from '@angular/platform-browser';
import { ButtonComponent } from './components/button/button.component';
import { ContainerComponent } from './components/container/container.component';
import { ContentHeaderComponent } from './components/content-header/content-header.component';
import { RouterModule } from '@angular/router';
@NgModule({
  declarations: [
    ButtonComponent,
    ContainerComponent,
    ContentHeaderComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    RouterModule,
    ReactiveFormsModule,
    HttpClientModule,
    BrowserModule,
    BrowserAnimationsModule,
  ],
  exports:[
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    ButtonComponent,
    ContentHeaderComponent,
    ContainerComponent
  ]
})
export class SharedModule { }
