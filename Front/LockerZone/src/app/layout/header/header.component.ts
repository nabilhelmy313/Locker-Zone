import { AfterViewInit, Component, ElementRef, OnInit, ViewChild } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit  {
  ngOnInit(): void {

  }

  menuItems = [
    { label: 'Home', path: '/home', icon: 'fa-solid fa-house-user' },
    { label: 'Lockers', path: '/address-book', icon: 'fa-solid fa-vault' },
    { label: 'Polices', path: '/polices', icon: 'fa-solid fa-building-shield' },
    { label: 'Feedback', path: '/feedback', icon: 'fa-solid fa-bug' },
    { label: 'About', path: '/about', icon: 'fa-regular fa-address-card' }
  ];
}
