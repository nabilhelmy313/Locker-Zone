import { HttpClient } from '@angular/common/http';
import { ServiceResponse } from './../../models/serviceResponse';
import { Injectable } from '@angular/core';
import { RegisterDto } from 'src/app/models/auth/RegisterDto';
import { Observable } from 'rxjs/internal/Observable';
import { LoginDto } from 'src/app/models/auth/LoginDto';
import { TokenDto } from 'src/app/models/auth/TokenDto';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private readonly apiUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }
  // varibles
  registerApi: string = `${this.apiUrl}Auth/Register`;
  loginApi: string = `${this.apiUrl}Auth/Login`;

  // functinos
  register(registerDto: RegisterDto): Observable<ServiceResponse<number>> {
    return this.http.post<ServiceResponse<number>>(this.registerApi, registerDto);
  }

  login(loginDto: LoginDto): Observable<ServiceResponse<TokenDto>> {
    return this.http.post<ServiceResponse<TokenDto>>(this.loginApi, loginDto);
  }
  GetToken(){
     let t=localStorage.getItem('token');
    let token = JSON.parse(t!);
    //  let token='';
    return token;
 }
  logout() {
    // remove user from local storage to log user out
    localStorage.clear();
  }
}
