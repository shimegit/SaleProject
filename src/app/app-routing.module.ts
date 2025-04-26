
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './component/home/home.component';
import { ShowGiftComponent } from './component/show-gift/show-gift.component';
import { DonorsComponent } from './component/donors/donors.component';
import { BasketComponent } from './component/buying/basket.component';
import { PayingComponent } from './component/paying/paying.component';
import { LoginComponent } from './component/login/login.component';
import { RegisterComponent } from './component/register/register.component';
import { RaffleComponent } from './component/raffle/raffle.component';

const routes: Routes = [
  { path: 'showgift', component: ShowGiftComponent },
  { path: 'donors', component: DonorsComponent },
  { path: '', component: HomeComponent },
  { path: 'busket', component: BasketComponent },
  { path: 'paying', component: PayingComponent },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'raffle', component: RaffleComponent }

]


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
