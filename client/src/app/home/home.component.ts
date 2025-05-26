import { Component, inject } from '@angular/core';
import { RegisterComponent } from "../register/register.component";
import { AccountService } from '../_services/account.service';
import { RouterLink, RouterLinkActive } from '@angular/router';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [RegisterComponent,RouterLink, RouterLinkActive,],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})

export class HomeComponent {
  registerMode = false;
  accountService = inject(AccountService);
  registerToddle() {
    this.registerMode = !this.registerMode
  }

  cancelRegisterMode(event: boolean){
    this.registerMode = event;
  }

}
