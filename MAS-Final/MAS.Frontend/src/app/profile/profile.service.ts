import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BasicInfoModel } from './models/basic-info.model';
import { UserAddressModel } from './models/user-address.model';

@Injectable({
  providedIn: 'root'
})
export class ProfileService {
  private readonly url = 'https://localhost:5001/api';

  constructor(private http: HttpClient) { }

  fetchBasicInfo(idUser: number) {
    return this.http.get<BasicInfoModel>(`${this.url}/profile/basic-info/${idUser}`);
  }

  updateBasicInfo(idUser: number, params: BasicInfoModel) {
    return this.http.put(`${this.url}/profile/basic-info/${idUser}`, { idUser, ...params });
  }

  fetchAddress(idUser: number) {
    return this.http.get<UserAddressModel>(`${this.url}/profile/address/${idUser}`);
  }

  updateAddress(idUser: number, params: UserAddressModel) {
    return this.http.put(`${this.url}/profile/address/${idUser}`, { idUser, ...params });
  }
}
