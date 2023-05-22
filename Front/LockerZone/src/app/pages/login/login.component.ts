import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/core/authentication/auth.service';
import { LoginDto } from 'src/app/models/auth/LoginDto';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loading: boolean = false;
  submitted: boolean = false;
  loginForm!: FormGroup;
  loginDto:LoginDto={email:'',password:''};

  constructor(
    private _authService: AuthService,
    // private _sweetalertService: SweetalertService,
    private formBuilder: FormBuilder,
    private _router: Router
  ) {
    this.loginForm = this.formBuilder.group({
      email: ['', Validators.required],
      password: ['', [Validators.required]],
    });
  }

  ngOnInit(): void {}

  get form() {
    return this.loginForm.controls;
  }

  onSubmit() {
    console.log(this.loginForm.value);

    if (this.loginForm.invalid) {
      return;
    }
    this.loading = true;
    this.loginDto=this.loginForm.value;
    console.log('logindto',this.loginDto);
    this._authService.login(this.loginDto).subscribe((res) => {
      console.log('rresss',res);
      if (res.success) {
        // this._sweetalertService.RunAlert(res.message, true);
        localStorage.setItem('token', JSON.stringify(res.data?.token));
        localStorage.setItem(
          'currentUser',
          JSON.stringify(res.data?.currentUser)
        ),
        // this._authService.sendIsLogin(true);
        this._router.navigate(['/home']).then(()=>{
          window.location.reload();
        });
      } else {
        // this._sweetalertService.RunAlert(res.message, false);
      }
    });
  }

}
