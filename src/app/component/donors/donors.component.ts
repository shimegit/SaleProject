

import { ConfirmationService, MessageService } from 'primeng/api';
import { Component, OnInit } from '@angular/core';
import { Donor } from 'src/app/domain/donor';
import { DonorService } from 'src/app/services/donorservice';
import { AppModule } from 'src/app/app.module';
import { TabMenuModule } from 'primeng/tabmenu';

@Component({
   selector: 'app-donors',
   templateUrl: './donors.component.html',
   styleUrls: ['./donors.component.css'],
   providers: [ConfirmationService, MessageService, DonorService]
})
export class DonorsComponent implements OnInit {

   productDialog: boolean;

   donors: Donor[];

   donor: Donor;

   selectedDonors: Donor[];

   submitted: boolean;

   gifts: any[];
   email: any[];
   items: any[];
   activeItem: any;

   constructor(private donorService: DonorService, private messageService: MessageService, private confirmationService: ConfirmationService) { }


   ngOnInit() {
      this.getAllGifts()
      this.items = [

         { label: 'donors ', icon: 'pi pi-id-card', routerLink: '/donors' },
         { label: 'raffle ', icon: 'pi pi-question-circle', routerLink: '/raffle' },
         { label: 'showgift ', icon: 'pi pi-gift', routerLink: '/showgift' }
      ];
      this.activeItem = this.items[0];

   }
   onActiveItemChange(event) {
      this.activeItem = event.item;
   }
   getAllGifts() {
      console.log(this.donors, "this.products 11");

      this.donorService.getDonors().subscribe((data: Donor[]) => {
         this.donors = data
      }
      )
      console.log(this.donors, "this.products 22");

   }
   openNew() {
      this.donor = {};
      this.submitted = false;
      this.productDialog = true;
   }
   editDonor(donor: Donor) {

      this.productDialog = true;
      this.donor = { ...donor };
      this.donorService.editDonor(donor).subscribe(res => {
         console.log(this.donors)

         this.donorService.getDonors()
      })

   }

   deleteDonor(donorId: number) {

      this.confirmationService.confirm({
         message: 'Are you sure you want to delete ' + donorId + '?',
         header: 'Confirm',
         icon: 'pi pi-exclamation-triangle',
         accept: () => {
            console.log(donorId)
            this.donorService.deleteDonor(donorId).subscribe(res => {
               console.log(this.donors)

               this.getAllGifts()
               
            })
            this.messageService.add({ severity: 'success', summary: 'Successful', detail: 'Product Deleted', life: 3000 });
         }
      });

   }

   hideDialog() {
      this.productDialog = false;
      this.submitted = false;
   }

   saveProduct() {
      this.submitted = true;

      if (this.donor.name.trim()) {
         if (this.donor.name) {

            this.donorService.editDonor(this.donor).subscribe(res => {
               console.log(this.donors)

               this.getAllGifts();
            })


         }
         else {
            this.donorService.addNewDonor(this.donor).subscribe(res => {
               console.log(this.donors)
               this.donorService.getDonors();
            })



            console.log(this.donorService.getDonors());
            this.messageService.add({ severity: 'success', summary: 'Successful', detail: 'Product Created', life: 3000 });
         }

         this.donorService.donors = [...this.donorService.donors];
         this.productDialog = false;
         this.donor = {};
      }
   }

   searchGiftByemail(email: string) {
      this.donorService.fingByemail(email).subscribe(data => {
         this.donors = data

         console.log(this.donors);
      }
      );
   }

   searchGiftByName(name: string) {
      this.donorService.fingByName(name).subscribe(data => {
         this.donors = data

         console.log(this.donors);
      }
      );
   }

} 
