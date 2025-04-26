
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ConfirmationService, MessageService } from 'primeng/api';
import { BehaviorSubject, Observable, map } from "rxjs";
import { Cart } from '../domain/Cart';
import { Gift } from '../domain/Gifts';
import { RaffleService } from './raffleService';

@Injectable()
export class CartService {
    constructor(private http: HttpClient, private messageService: MessageService, private confirmationService: ConfirmationService) { }

    showMyCart(): Observable<Cart[]> {

        let url = 'https://localhost:7035/api/Order/ShowMyCart1 ';

        return this.http.get<Cart[]>(url);


    }
    addToCart(giftId: number) {
        console.log(giftId);

        let url = `https://localhost:7035/api/Order/addToBasket?giftId=${giftId}`;

        return this.http.post(url, giftId);


    }
    removeFromCart(giftId: number) {


        let url = `https://localhost:7035/api/Order/RemoveQuantityFromBasket?giftId=${giftId}`

        return this.http.post(url, giftId);
    }
    PayingForCart(): Observable<number> {

        let url = 'https://localhost:7035/api/Order/Payment'
        return this.http.post<number>(url, {});
    }
    deletFromMyCart(giftId: number) {

        let url = `https://localhost:7035/api/Order/deletItemFromBusket?giftId=${giftId}`
        return this.http.delete(url);
    }
    sumforPaying() {
        let url = 'https://localhost:7035/api/Order/SumForPaying'
        return this.http.get<number>(url);
    }
}