import { Component, OnInit } from '@angular/core';
import { GetLockerDto } from 'src/app/models/lockers/GetLockerDto';
import { LockerService } from 'src/app/shared/services/locker.service';
import { SweetalertService } from 'src/app/shared/services/sweetalert.service';

@Component({
  selector: 'app-admin-home',
  templateUrl: './admin-home.component.html',
  styleUrls: ['./admin-home.component.css']
})
export class AdminHomeComponent implements OnInit {

  lockers: GetLockerDto[] | null = [];
  errorMessage: string = '';

  constructor(private lockerService: LockerService,private _sweetalertService:SweetalertService) {}

  ngOnInit() {
    this.getLockersAdmin();
  }

  getLockersAdmin(): void {
    this.lockerService.getLockersAdmin().subscribe((response) => {
      if (response.success) {
        this.lockers = response.data;
        console.log('res',response.data);
      } else {
        this.errorMessage = response.message;
      }
    });
  }
  refundLocker(id:string){
    this.lockerService.refundLocker(id).subscribe(res=>{
      this._sweetalertService.RunAlert(res.message,res.success);
      this.getLockersAdmin();
    })
  }

}
