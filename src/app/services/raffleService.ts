import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { MessageService, ConfirmationService } from 'primeng/api';

@Injectable({
  providedIn: 'root'
})
export class RaffleService {
  private isRafflingSubject = new BehaviorSubject<boolean>(false);
  isRaffling$ = this.isRafflingSubject.asObservable();

  constructor(
    private http: HttpClient,
    private messageService: MessageService,
    private confirmationService: ConfirmationService
  ) {}

  setRaffling(value: boolean): void {
    this.isRafflingSubject.next(value);
  }

  rafflling(): Observable<boolean> {
    const url = 'https://localhost:7035/api/Winner/Raffle';
    return this.http.get<boolean>(url);
  }

  getWinnerReport(): Observable<any> {
    const url = 'https://localhost:7035/api/Winner/GetWinners';
  
    return this.http.get<any>(url);
  }
}
