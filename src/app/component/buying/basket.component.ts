import { Component, OnInit, Input } from '@angular/core';
import { Gift } from 'src/app/domain/Gifts';
import { ProductService } from 'src/app/services/productservice';
import { ConfirmationService, MessageService } from 'primeng/api';
import { DialogModule } from 'primeng/dialog';
import { ActivatedRoute, Router } from '@angular/router';
import { count } from 'rxjs';
import { Cart } from 'src/app/domain/Cart';
import { CartService } from 'src/app/services/cartService';
import { RaffleService } from 'src/app/services/raffleService';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-basket',
  templateUrl: './basket.component.html',
  styleUrls: ['./basket.component.css'],
  providers: [ConfirmationService, MessageService, ProductService, CartService]
})
export class BasketComponent implements OnInit {
  constructor(private productService: ProductService, private messageService: MessageService, private confirmationService: ConfirmationService, private router: Router, private activetedRoute: ActivatedRoute, private cartService: CartService, private RaffleService: RaffleService) { }

  products: Gift[];
  product: Gift;
  submitted: boolean;
  sss: boolean = false;
  chosenGifts: Cart[] = [];
  quntity: number[] = [];
  sum: number;
  winnerReport: any[] = [];
  category: string;
  name: string;
  visible: boolean = false;
  isRaffling: boolean = true; // נניח שברירת מחדל היא שניתן להשתתף

  ngOnInit(): void {
    this.RaffleService.isRaffling$.subscribe(val => {
      this.isRaffling = val;
      console.log("isRaffling", this.isRaffling)
    });
  
    this.getAllGifts();
  }

  // ngOnInit(): void {
  //   this.getAllGifts()

  // }
  getAllGifts() {
    this.productService.getProducts().subscribe((data: Gift[]) => {
      this.products = data
    // this.isRaffling = false;
    }
    )

  }
  chothen(giftId: number) {
    this.RaffleService.isRaffling$.subscribe(isRaffling => {
      if (!isRaffling) {
        Swal.fire({
          title: 'אינך יכול להוסיף לסל - ההגרלה כבר בוצעה',
          text: `😌`,
          icon: 'error',
          confirmButtonText: 'OK',
        });
        return;
      }
  
      this.cartService.addToCart(giftId).subscribe(res => {
        console.log("Gift added to cart");
      });
  
      Swal.fire({
        title: 'מתנה חדשה נוספה לעגלתך',
        text: `😀`,
        icon: 'success',
        confirmButtonText: 'OK',
      });
    });
  }

  showDialog() {
    this.visible = true;
  }

  showMyCart() {
    this.showDialog()
    this.cartService.showMyCart().subscribe(data => {
      this.chosenGifts = data;
      console.log(this.chosenGifts);

    })
  }
  pay() {

    this.cartService.sumforPaying().subscribe(res => {
      this.sum = res;
      this.router.navigate(['/paying'], { queryParams: { sum: this.sum } })
    })

  }
  removeFromCart(giftId: number) {

    this.cartService.removeFromCart(giftId).subscribe(res => {
      console.log("deleted")
      this.showMyCart();
    })
  }
  deletFromMyCart(giftId: number) {
    this.cartService.deletFromMyCart(giftId).subscribe(res => {
      this.showMyCart();
    })
  }
  searchGiftByCategory(category: string) {
    this.productService.fingByCategory(category).subscribe(data => {
      this.products = data
      console.log(this.products);
    }
    );
  }
  searchGiftByName(name: string) {
    this.productService.fingByName(name).subscribe(data => {
      this.products = data
      console.log(this.products);
    }
    );
  }
  getWinnerReport(): void {
    this.showDialog();
    this.RaffleService.getWinnerReport().subscribe(data => {
      this.winnerReport = data
      console.log(this.winnerReport);
    }

    );
  }
  log() {
    this.router.navigate(['/login'])
  }

}
