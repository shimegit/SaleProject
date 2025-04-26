
import { Component, OnInit } from '@angular/core';
import { Costumer } from 'src/app/domain/costumer';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import Swal from 'sweetalert2';

import { ConfirmationService, MessageService } from 'primeng/api';
import { CartService } from 'src/app/services/cartService';

@Component({
  selector: 'app-paying',
  templateUrl: './paying.component.html',
  styleUrls: ['./paying.component.css'],
  providers: [ConfirmationService, MessageService, CartService]
})
export class PayingComponent implements OnInit {
  paymentForm: FormGroup;
  sum: number;
  customer: Costumer;
  customers: Costumer[];
  frmCustomer: FormGroup = new FormGroup({});
  ncard: string;
  cardHolderName: string;
  expirationDate: string;
  securityNumber: string;
  isDisabled: boolean;
  emailReg: RegExp = new RegExp('[]@[a-z].[a-z]')
  constructor(private activatedRoute: ActivatedRoute, private route: ActivatedRoute, private cartService: CartService, private router: Router, private formBuilder: FormBuilder) {
  }
  ngOnInit() {
    this.route.queryParams.subscribe(params => {
      this.sum = params['sum'];
    });
    this.paymentForm = this.formBuilder.group({
      ncard: ['', Validators.required],
      cardHolderName: ['', Validators.required],
      expirationDate: ['', Validators.required],
      securityNumber: ['', Validators.required]
    });
  }

  validateFields() {
    if (this.ncard && this.cardHolderName && this.expirationDate && this.securityNumber) {
      this.isDisabled = true;
    } else {
      this.isDisabled = false;
    }
  }
  get() {

  }

  save() {
    this.customer.firstName = this.frmCustomer['firstName'].value
    this.customer.lastName = this.frmCustomer['lastName'].value
    this.customer.address = this.frmCustomer['adress'].value
    this.customer.phone = this.frmCustomer['phone'].value
    this.customer.email = this.frmCustomer['email'].value

  }
  pay() {
    const sum = this.sum;

    Swal.fire({
      title: 'Confirm Payment',
      text: `By clicking OK, you confirm payment of ${sum}`,
      icon: 'info',
      showCancelButton: true,
      confirmButtonText: 'OK',
      cancelButtonText: 'Cancel',
    }).then((result) => {
      if (result.isConfirmed) {
        this.cartService.PayingForCart().subscribe(
          () => {
            Swal.fire({
              title: 'Payment Received',
              text: 'The payment was successfully received, thank you!',
              icon: 'success',
              confirmButtonText: 'OK',
            }).then(() => {
              this.router.navigate(['busket']);
            });
          },
          () => {
            Swal.fire({
              title: 'Payment Failed',
              text: 'There was an error processing the payment. Please try again later.',
              icon: 'error',
              confirmButtonText: 'OK',
            });
          }
        );
      }
    });
  }
}


