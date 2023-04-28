import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { SharedModule } from '../shared/shared.module';
import { RouterModule } from '@angular/router';
import { BlankLayoutComponent } from './blank-layout/blank-layout.component';

@NgModule({
  declarations: [
    // HeaderComponent,
    // FooterComponent

    // BlankLayoutComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    SharedModule
  ]
})
export class MainLayoutModule { }
