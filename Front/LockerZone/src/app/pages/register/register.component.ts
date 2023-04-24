import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/core/authentication/auth.service';
import { RegisterDto } from 'src/app/models/auth/RegisterDto';
import { SweetalertService } from 'src/app/shared/services/sweetalert.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  loading: boolean = false;
  submitted: boolean = false;
  registerForm!: FormGroup;
  registerDto:RegisterDto={email:'',password:'',fullName:''};

  constructor(
    private _authService: AuthService,
    private _sweetalertService: SweetalertService,
    private formBuilder: FormBuilder,
    private _router: Router
  ) {
    this.registerForm = this.formBuilder.group({
      fullName:['',Validators.required],
      email: ['', Validators.required],
      password: ['', [Validators.required]],
    });
  }

  ngOnInit(): void {}

  get form() {
    return this.registerForm.controls;
  }

  onSubmit() {
    console.log(this.registerForm.value);

    if (this.registerForm.invalid) {
      return;
    }
    this.loading = true;
    this.registerDto=this.registerForm.value;
    console.log('logindto',this.registerForm);
    this._authService.register(this.registerDto).subscribe((res) => {
      console.log('rresss',res);
      if (res.success) {
        this._sweetalertService.RunAlert(res.message, true);

        // this._authService.sendIsLogin(true);
        // this._router.navigate(['/']).then(()=>{
        //   window.location.reload();
        // });
      } else {
        this._sweetalertService.RunAlert(res.message, false);
      }
    });
  }

}
