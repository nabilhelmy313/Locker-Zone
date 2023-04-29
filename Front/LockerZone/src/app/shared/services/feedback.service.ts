import { FeedbackMessageDto } from './../../models/FeedbackMessageDto';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ServiceResponse } from 'src/app/models/serviceResponse';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class FeedbackService {
  private readonly apiUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }
  // varibles
  private sendFeebackApi: string = `${this.apiUrl}Feedback/SendFeeback`;
  sendFeedback(fe0edbackMessageDto: FeedbackMessageDto): Observable<ServiceResponse<number>> {
    return this.http.post<ServiceResponse<number>>(this.sendFeebackApi, fe0edbackMessageDto);
  }
}
