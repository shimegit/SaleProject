
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ConfirmationService, MessageService } from 'primeng/api';
import { Gift } from '../domain/Gifts';
import { BehaviorSubject, Observable, map } from "rxjs";


@Injectable()
export class PayingService {

    status: string[] = ['OUTOFSTOCK', 'INSTOCK', 'LOWSTOCK'];
    productDialog: boolean;

    products: Gift[];

    product: Gift;

    selectedProducts: Gift[];

    submitted: boolean;

    donors: any[];

    constructor(private http: HttpClient, private messageService: MessageService, private confirmationService: ConfirmationService) { }


    getAllGifts(): Observable<Gift[]> {
        let url = 'https://localhost:7035/api/Gift/getGifts'
        return this.http.get<Gift[]>(url)
            .pipe(map(l => this.products = l));


    }
}
