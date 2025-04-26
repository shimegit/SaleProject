import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ConfirmationService, MessageService } from 'primeng/api';
import { BehaviorSubject, Observable, map } from "rxjs";

import { Donor } from '../domain/donor';


@Injectable()
export class DonorService {

    status: string[] = ['OUTOFSTOCK', 'INSTOCK', 'LOWSTOCK'];
    donors: Donor[];
    selectedDonors: Donor[];
    donor: Donor;
    submitted: boolean;

    productDialog: boolean;


    constructor(private http: HttpClient, private messageService: MessageService, private confirmationService: ConfirmationService) { }

    getDonors(): Observable<Donor[]> {
        let url = 'https://localhost:7035/api/Donor'
        return this.http.get<Donor[]>(url)
            .pipe(map(l => this.donors = l));


    }

    editDonor(donor: Donor) {
        let url = 'https://localhost:7035/api/Donor/UpdateDonor';
        console.log(donor)
        return this.http.put<number>(url, donor)


    }

    deleteDonor(id: number) {
        
        let url = 'https://localhost:7035/api/Donor/' + id
        return this.http.delete(url);
    }

    addUpdatedDonor(g: Donor) {
        this.donors[this.findIndexByName(g.name)] = g;
    }

    addNewDonor(g: Donor) {
       let url = 'https://localhost:7035/api/Donor';
       // let url = 'https://localhost:5111/api/Donor/donors/addDonor';
        return this.http.post(url, g);
    }
    findIndexByName(name: string): number {
        let index = -1;
        for (let i = 0; i < this.donors.length; i++) {
            if (this.donors[i].name === name) {
                index = i;
                console.log(index)
                break;
            }
        }
        console.log("findI");
        return index;
    }
    fingByemail(email: string) {

        const url = `https://localhost:7035/api/Donor/findbymail?g=${email}`;
        return this.http.get<any>(url);
    }
    fingByName(name: string) {
        const url = `https://localhost:7035/api/Donor/findbyname?g=${name}`;
        return this.http.get<any>(url);
    }

}