import { Component, inject } from '@angular/core';
import { RegisterComponent } from "../register/register.component";
import { AccountService } from '../_services/account.service';
import { RouterLink, RouterLinkActive } from '@angular/router';
import { WeddingComponent } from "../wedding/wedding.component";
import { WeddingService } from '../_services/wedding.service';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [RegisterComponent],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})

export class HomeComponent {
  registerMode = false;
  showWeddingForm = false;
  accountService = inject(AccountService);
  weddingService = inject(WeddingService);
  registerToddle() {
    this.registerMode = !this.registerMode
  }

  cancelRegisterMode(event: boolean){
    this.registerMode = event;
  }

  openWeddingForm() {
    this.showWeddingForm = !this.showWeddingForm;
  }

  closeWeddingForm() {
    this.showWeddingForm = false;
  }

}
