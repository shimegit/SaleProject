
import { Component, OnInit } from '@angular/core';
import { ConfirmationService, MessageService } from 'primeng/api';
import { Gift } from 'src/app/domain/Gifts';
import { ProductService } from 'src/app/services/productservice';
import { ActivatedRoute, Router } from '@angular/router';
import { DonorService } from 'src/app/services/donorservice';
import { Donor } from 'src/app/domain/donor';
import { AppModule } from 'src/app/app.module';
import { TabMenuModule } from 'primeng/tabmenu';
import Swal from 'sweetalert2';


// ProductService
@Component({
    selector: 'app-show-gift',
    templateUrl: './show-gift.component.html',
    styleUrls: ['./show-gift.component.css'],
    providers: [ConfirmationService, MessageService, ProductService, DonorService]
})
export class ShowGiftComponent implements OnInit {

    productDialog: boolean;

    products: Gift[];

    product: Gift;

    selectedProducts: Gift[];

    submitted: boolean;

    categories: any[];
    category: string;
    donors: Donor[] = [];
    items: any[];
    activeItem: any;
    isPriceLessThan10: boolean = false;
 
    constructor(private router:Router,public productService: ProductService, private messageService: MessageService, private confirmationService: ConfirmationService, private donorService: DonorService) { }

    ngOnInit() {
        this.getAllGifts()
        this.categories = [
            { label: 'בית', value: 'בית' },
            { label: 'חופשות', value: 'חופשות' },
            { label: 'שופינג', value: 'שופינג' }
        ];
        this.donorService.getDonors().subscribe((data: Donor[]) => {
            this.donors = data
        }
        )
        this.items = [
          {label: 'donors ', icon: 'pi pi-id-card',routerLink: '/donors'},
          {label: 'raffle ', icon: 'pi pi-question-circle',routerLink: '/raffle'},
          {label: 'showgift ', icon: 'pi pi-gift',routerLink: '/showgift'},
        ];
        this.activeItem = this.items[0];
      }
      
      onActiveItemChange(event) {
        this.activeItem = event.item;
    }

    getAllGifts() {
        console.log(this.products, "this.products 11");

        this.productService.getProducts().subscribe((data: Gift[]) => {
            this.products = data
        }
        )
        console.log(this.products, "this.products 22");

    }
    openNew() {
        this.product = {};
        this.submitted = false;
        this.productDialog = true;
    }

    editProduct(product: Gift) {
       

        this.productDialog = true;
        this.product = { ...product };
        this.productService.editProduct(product).subscribe(res => {
            console.log(res)
            this.productService.getProducts()
        })

    }
    deleteProduct(product: number) {
        this.confirmationService.confirm({
            message: 'Are you sure you want to delete ' + product + '?',
            header: 'Confirm',
            icon: 'pi pi-exclamation-triangle',
            accept: () => {

                this.productService.deleteProduct(product).subscribe(res => {
                    console.log(this.products)
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
      
        if (this.product.name.trim()) {
          console.log(this.products);
          
          const existingProduct = this.products.find(p => p.name === this.product.name && p.id !== this.product.id);
          if (existingProduct) {
            this.productDialog = false;
            Swal.fire({
              title: 'Erorr',
              text: `Name already exists`,
              icon: 'info',
              confirmButtonText: 'OK',
            })
            return;
          }
      
          if (this.product.id) {
            this.productService.editProduct(this.product).subscribe(res => {
              console.log(res);
              this.getAllGifts();
            });
          } else {
            this.productService.addNewProduct(this.product).subscribe(res => {
              console.log(res);
              this.products.push(res);
              this.getAllGifts();
            }, error => {
              console.error(error);
              this.messageService.add({ severity: 'error', summary: 'Error', detail: 'Failed to add product' });
            });
          }
      
          this.productDialog = false;
          this.product = {};
        }
      }
      validateTicketPrice() {
        this.isPriceLessThan10 = this.product.tiketPrice < 10;
      }
   }
  
