import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AddLockerDto } from 'src/app/models/lockers/AddLockerDto';
import { EditLockerDto } from 'src/app/models/lockers/EditLockerDto';
import { GetLockerDto } from 'src/app/models/lockers/GetLockerDto';
import { ServiceResponse } from 'src/app/models/serviceResponse';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class LockerService {
  private readonly apiUrl = environment.apiUrl;
  constructor(private http: HttpClient) { }
  private GetLockersApi: string = `${this.apiUrl}Api/Lokcer/GetLockers`;
  private GetLockerApi: string = `${this.apiUrl}Api/Lokcer/GetLocker`;
  private AddLockerApi: string = `${this.apiUrl}Api/Lokcer/AddLocker`;
  private EditLockerApi: string = `${this.apiUrl}Api/Lokcer/EditLocker`;
  private DeleteLockerApi: string = `${this.apiUrl}Api/Lokcer/DeleteLocker`;
  addLocker(addlocker: AddLockerDto): Observable<ServiceResponse<number>> {
    return this.http.post<ServiceResponse<number>>(this.AddLockerApi, addlocker);
  }
  editlokcer(edit:EditLockerDto){
    return this.http.put<ServiceResponse<number>>(this.EditLockerApi, edit);
  }
  deleteLocker(id:string){
    return this.http.delete<ServiceResponse<number>>(`${this.DeleteLockerApi}?id=${id}`);
  }
  getLocker(id:string):Observable<ServiceResponse<GetLockerDto>>{
    return this.http.get<ServiceResponse<GetLockerDto>>(`${this.GetLockerApi}?id=${id}`);
  }
  getLockers():Observable<ServiceResponse<GetLockerDto[]>>{
    return this.http.get<ServiceResponse<GetLockerDto[]>>(`${this.GetLockersApi}`);
  }

}
