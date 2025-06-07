import { Component,  inject,  input, output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AccountService } from '../_services/account.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {
private accountService = inject(AccountService);
private toastr = inject(ToastrService);
private router = inject(Router);
usersFromHomeComponent = input.required<any>();
cancelRegister = output<boolean>();
model: any = {}

register() {
  this.accountService.register(this.model).subscribe({
    next: response => {
      console.log(response);
      this.router.navigateByUrl('/role');
    },
    error: error => this.toastr.error(error.error)
  })
}

cancel() {
  this.cancelRegister.emit(false);
}

}
