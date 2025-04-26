import { Injectable } from '@angular/core';
import { Gift } from '../domain/Gifts';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ConfirmationService, MessageService } from 'primeng/api';
import { Observable, map } from 'rxjs';
import { User } from '../domain/user';
import { Login } from '../domain/userLogin';
import { JsonPipe } from '@angular/common';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  user: User;
  Users: User[];
  constructor(private http: HttpClient, private messageService: MessageService, private confirmationService: ConfirmationService) {

  }
  CreateNewUser(c: User): Observable<any> {
    let url = 'https://localhost:7035/api/User/register';
    return this.http.post<any>(url, c);
  }

  login(userLogin: Login): Observable<any> {
    let url = 'https://localhost:7035/api/Login';
    return this.http.post<any>(url, userLogin);
  }
}








