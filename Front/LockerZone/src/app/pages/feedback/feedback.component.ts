import { SweetalertService } from './../../shared/services/sweetalert.service';
import { FeedbackService } from './../../shared/services/feedback.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-feedback',
  templateUrl: './feedback.component.html',
  styleUrls: ['./feedback.component.css']
})
export class FeedbackComponent implements OnInit {
  feedbackForm!: FormGroup;

  constructor( private formBuilder: FormBuilder,
    private _router: Router,private _feedbackService:FeedbackService,private _sweetalertService:SweetalertService) {
    this.feedbackForm = this.formBuilder.group({
      name: ['', Validators.required],
      email: ['', [Validators.required]],
      message:['',[Validators.required]]
    });
   }

  ngOnInit(): void {
  }
  get form() {
    return this.feedbackForm.controls;
  }
  onSubmit(){
    this._feedbackService.sendFeedback(this.feedbackForm.value).subscribe(res=>{
      this._sweetalertService.RunAlert(res.message,res.success)
    })
    console.log('feedback',this.feedbackForm.value);
  }
}
