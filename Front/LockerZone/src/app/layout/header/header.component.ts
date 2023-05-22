import { ActivatedRoute, Router } from '@angular/router';
import { AfterViewInit, Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { AuthService } from 'src/app/core/authentication/auth.service';
import { UsersEnum } from 'src/app/models/usersEnum';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit  {
  constructor(private _authService:AuthService,private _router:Router){

  }
  currentRole=null;
  ngOnInit(): void {
    let user=localStorage.getItem('currentUser');
    if(user==null)return
    else {
      this.currentRole= JSON.parse(user).roleName;
      console.log('curent',this.currentRole);
    }
  }
  logout(){
    this._authService.logout();
    this._router.navigate(['login']);
  }
  menuItems = [
    { label: 'Home', path: '/home', icon: 'fa-solid fa-house-user',role:UsersEnum.PUBLC },
    { label: 'home Admin', path: '/homeAdmin', icon: 'fa-solid fa-house-user',role:UsersEnum.ADMIN },
    // { label: 'Lockers', path: '/address-book', icon: 'fa-solid fa-vault', },
    { label: 'polices', path: '/polices', icon: 'fa-solid fa-building-shield',role:UsersEnum.PUBLC },
    { label: 'Feedback', path: '/feedback', icon: 'fa-solid fa-bug' ,role:UsersEnum.PUBLC},
    { label: 'About', path: '/about', icon: 'fa-regular fa-address-card',role:UsersEnum.PUBLC },
    { label: 'Add Locker', path: '/addLocker', icon: 'fa-solid fa-file-circle-plus',role:UsersEnum.ADMIN },
    { label: 'Admin Lockers', path: '/adminLockers', icon: 'fa-solid fa-vault',role:UsersEnum.ADMIN }
  ];
}
