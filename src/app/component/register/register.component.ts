
  import { Component } from '@angular/core';
   import { HttpClient } from '@angular/common/http';
   import { User } from 'src/app/domain/user';
   import { UserService } from 'src/app/services/UserService';
   import { ActivatedRoute, Router } from '@angular/router';
   import { ConfirmationService, MessageService } from 'primeng/api';
import Swal from 'sweetalert2';


   @Component({
     selector: 'app-registration',
     templateUrl: './register.component.html',
     styleUrls: ['./register.component.css'],   
       providers: [ConfirmationService,MessageService,UserService]
   })
   export class RegisterComponent {
     users:User[] 
     user?: User = {};
     id: string;
     Register:any;

     constructor(private http: HttpClient,private UserService:UserService,private router:Router) { }

     register() {
      console.log(this.user)
      this.UserService.CreateNewUser(this.user).subscribe(data => {
        this.Register = data
        // console.log(data);
        Swal.fire({
          title: 'משתמש נוסף בהצלחה',
          icon: 'success',
          confirmButtonText: 'OK',
        })
         this.router.navigate(['']);
      });
     }
   
   }

