import { LayoutEnum } from './models/layoutEnum';
import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  constructor(){}
  title = 'LockerZone';
  get layoutEnumType(){
        return LayoutEnum;
  }
}
