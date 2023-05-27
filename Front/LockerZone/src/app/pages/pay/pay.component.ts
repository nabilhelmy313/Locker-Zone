import { SweetalertService } from 'src/app/shared/services/sweetalert.service';
import { LockerService } from './../../shared/services/locker.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-pay',
  templateUrl: './pay.component.html',
  styleUrls: ['./pay.component.css']
})
export class PayComponent implements OnInit {

  constructor(private lockerService:LockerService,private _sweetalertService:SweetalertService,private route:Router) { }

  ngOnInit(): void {
  }
  resereveLocker(id:string){
    this.lockerService.ReserveLocker(id).subscribe(res=>{
      this._sweetalertService.RunAlert(res.message,res.success);
    });
    this.route.navigate(['pay'])
  }
}
