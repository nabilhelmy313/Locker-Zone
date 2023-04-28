import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-blank-layout',
 template:'<router-outlet></router-outlet>',
//  standalone:true,
  styleUrls: ['./blank-layout.component.css']
})
export class BlankLayoutComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}
