import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ConfirmationService, MessageService } from 'primeng/api';
import { RaffleService } from 'src/app/services/raffleService';
import Swal from 'sweetalert2';
import { __values } from 'tslib';

@Component({
  selector: 'app-raffle',
  templateUrl: './raffle.component.html',
  styleUrls: ['./raffle.component.css'],
  providers: [ConfirmationService]
})
export class RaffleComponent implements OnInit {
  winnerReport: any[] = [];
  visible: boolean = false;
  items: any[] = [];
  activeItem: any;
  isRaffling: boolean = true; // מצב התחלתי של ההגרלה

  constructor(private raffleService: RaffleService, private http: HttpClient, private messageService: MessageService) {}

  ngOnInit() {
    // תפריט ניווט
    this.items = [
      { label: 'donors ', icon: 'pi pi-id-card', routerLink: '/donors' },
      { label: 'raffle ', icon: 'pi pi-question-circle', routerLink: '/raffle' },
      { label: 'showgift ', icon: 'pi pi-gift', routerLink: '/showgift' }
    ];
    this.activeItem = this.items[0];

    // קבלת מצב ההגרלה
    this.raffleService.isRaffling$.subscribe(value => {
      this.isRaffling = value;
    });
  }

  onActiveItemChange(event: any) {
    this.activeItem = event.item;
  }

  // הפעלת ההגרלה
  raffle(): void {
    this.raffleService.setRaffling(false);
    console.log("הגרלה", this.raffleService.setRaffling)  // עדכון שההגרלה התבצעה
    this.raffleService.rafflling().subscribe(result => {
      if (result) {
        Swal.fire({
          text: 'The lottery was successfully completed! For the results, click on the winners button!',
          icon: 'success',
          confirmButtonText: 'OK',
        });
      } else {
        console.log('Lottery failed!');
      }
    });
  }

  // הצגת דיאלוג עם המנצחים
  showDialog() {
    this.visible = true;
  }

  // הצגת המנצחים
  getWinnerReport(): void {
    this.showDialog();
    this.raffleService.getWinnerReport().subscribe(data => {
      this.winnerReport = data;
    });
  }

  // פונקציה לאיפוס המצב
  resetRaffle(): void {
    // this.visible = false;  
    this.winnerReport = [];
  
    this.raffleService.setRaffling(true); // מחזיר את האפשרות להוסיף לסל
  }
  
}
