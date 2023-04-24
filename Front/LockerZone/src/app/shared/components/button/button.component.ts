import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-button',
  templateUrl: './button.component.html',
  styleUrls: ['./button.component.css']
})
export class ButtonComponent implements OnInit {

  constructor() { }
  @Input() text:string=''
  @Output() onClicked = new EventEmitter();

  ngOnInit(): void {
  }
  onClick() {
    this.onClicked.emit();
  }

}
