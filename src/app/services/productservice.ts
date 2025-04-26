import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ConfirmationService, MessageService } from 'primeng/api';
import { Gift } from '../domain/Gifts';
import { BehaviorSubject, Observable, map } from "rxjs";


@Injectable()
export class ProductService {

    status: string[] = ['OUTOFSTOCK', 'INSTOCK', 'LOWSTOCK'];
    productDialog: boolean;

    products: Gift[];

    product: Gift;

    selectedProducts: Gift[];

    submitted: boolean;

    donors: any[];
    constructor(private http: HttpClient, private messageService: MessageService, private confirmationService: ConfirmationService) { }


    getProducts(): Observable<Gift[]> {

        let url = 'https://localhost:7035/api/Gifts'
        return this.http.get<Gift[]>(url)
    }
    editProduct(product: Gift) {
        let url = 'https://localhost:7035/api/Gifts/updateGift'
        return this.http.put<number>(url, product)
    }

    deleteProduct(id: number) {
        let url = 'https://localhost:7035/api/Gifts/' + id;
        return this.http.delete(url);

    }
    addUpdatedProduct(g: Gift) {
        console.log(this.product)
        this.products[this.findIndexById(g.id)] = g;

    }
    fingByCategory(categoryName: string) {

        const url = `https://localhost:7035/api/Gifts/findbycategory?category=${categoryName}`;



        return this.http.get<any>(url);
    }
    fingByName(Name: string) {

        const url = `https://localhost:7035/api/Gifts/findbyname?g=${Name}`;
        return this.http.get<any>(url);
    }

    addNewProduct(g: Gift) {
        console.log(g);

        let url = 'https://localhost:7035/api/Gifts'
        return this.http.post(url, g);
    }

    findIndexById(id: Number): number {
        let index = -1;
        for (let i = 0; i < this.products.length; i++) {
            if (this.products[i].id === id) {
                index = i;
                console.log(index)
                break;
            }
        }

        return index;
    }
    id: number = 0;

    createId() {


        let max = this.products.map(l => l.id).sort().pop();
        return max + 1;
    }


}