import { Component, EventEmitter } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from 'src/app/domain/user';
import { UserService } from 'src/app/services/UserService';
import { Login } from 'src/app/domain/userLogin';
import { ActivatedRoute, Router } from '@angular/router';
import { ConfirmationService, MessageService } from 'primeng/api';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import Swal from 'sweetalert2';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  providers: [ConfirmationService, MessageService, UserService]
})
export class LoginComponent {
  ngOnInit(): void {
    this.user = {};
  }

  user: User = {};
  users: User[]
  myUser?: User = {};
  id: string;
  Register: any;
  userToLogin: Login;
  loginChange: EventEmitter<boolean> = new EventEmitter<boolean>();

  constructor(private router: Router, private userService: UserService, private http: HttpClient) {

  }

  login() {
    this.userToLogin = {
      UserName: this.user.UserName,
      Password: this.user.Password,
    };
    console.log(this.userToLogin);
    this.userService.login(this.userToLogin).subscribe(
      (response: any) => {
        console.log(response?.token, "kh;fkgpdsjfos");
        if (response) {
          sessionStorage.setItem('token', response?.token);
          this.router.navigate(['busket']);
          if (this.userToLogin.UserName == "shifim" && this.userToLogin.Password == "123456") {
            this.router.navigate(['showgift']);
          }
        } else {
          console.log('User not found');
          Swal.fire({
            text: 'User does not exist, transferred to registration page.',
            icon: 'error',
            confirmButtonText: 'OK',
          });
          this.router.navigate(['register']);
        }
      },
      (error: any) => {
        console.log('An error occurred:', error);
      }
    );
  }
  register() {
    this.loginChange.emit(false);
    this.router.navigate(['register']);
  }
}
