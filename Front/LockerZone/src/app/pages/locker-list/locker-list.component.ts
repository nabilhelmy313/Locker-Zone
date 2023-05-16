import { Component, OnInit } from '@angular/core';
import { GetLockerDto } from 'src/app/models/lockers/GetLockerDto';
import { LockerService } from 'src/app/shared/services/locker.service';

@Component({
  selector: 'app-locker-list',
  templateUrl: './locker-list.component.html',
  styleUrls: ['./locker-list.component.css']
})
export class LockerListComponent implements OnInit {

  lockers: GetLockerDto[]|null=[];
  errorMessage: string='';

  constructor(private lockerService: LockerService) { }

  ngOnInit() {
    this.getLockers();
  }

  getLockers(): void {
    this.lockerService.getLockers().subscribe(
      response => {
        if (response.success) {
          this.lockers = response.data;
        } else {
          this.errorMessage = response.message;
        }
      })
    }
}
