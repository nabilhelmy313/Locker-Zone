import { SweetalertService } from './../../shared/services/sweetalert.service';
import { Component, OnInit } from '@angular/core';
import { GetLockerDto } from 'src/app/models/lockers/GetLockerDto';
import { LockerService } from 'src/app/shared/services/locker.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent implements OnInit {
  lockers: GetLockerDto[] | null = [];
  errorMessage: string = '';

  constructor(private lockerService: LockerService,private _sweetalertService:SweetalertService) {}

  ngOnInit() {
    this.getLockers();
  }

  getLockers(): void {
    this.lockerService.getLockers().subscribe((response) => {
      if (response.success) {
        this.lockers = response.data;
        console.log('res',response.data);
      } else {
        this.errorMessage = response.message;
      }
    });
  }
  resereveLocker(id:string){
    this.lockerService.ReserveLocker(id).subscribe(res=>{
      this._sweetalertService.RunAlert(res.message,res.success);
      this.getLockers();
    })
  }
}
