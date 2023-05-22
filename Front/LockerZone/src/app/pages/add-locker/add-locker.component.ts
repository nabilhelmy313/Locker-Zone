import { SweetalertService } from './../../shared/services/sweetalert.service';
import { LockerService } from 'src/app/shared/services/locker.service';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AddLockerDto } from 'src/app/models/lockers/AddLockerDto';

@Component({
  selector: 'app-add-locker',
  templateUrl: './add-locker.component.html',
  styleUrls: ['./add-locker.component.css']
})
export class AddLockerComponent implements OnInit {

  addLockerForm: FormGroup;

  constructor(private formBuilder: FormBuilder,
    private _lockerService:LockerService,
    private _sweetalertService:SweetalertService,) {
    this.addLockerForm = this.formBuilder.group({
      number: ['', Validators.required],
      price: ['', Validators.required],
      fromDay: ['', Validators.required],
      toDay: ['', Validators.required],
      description: ''
    });
  }

  onSubmit() {
    if (this.addLockerForm.valid) {
      const formData: AddLockerDto = this.addLockerForm.value;
      this._lockerService.addLocker(formData).subscribe(res=>{
        this._sweetalertService.RunAlert(res.message,res.success);

      })
      // Do something with the form data, such as sending it to an API
    } else {
        this._sweetalertService.RunAlert('fill all Needed Input',false)
      // Form is invalid, handle validation errors or display error messages
    }
  }

  ngOnInit(): void {
  }

}
