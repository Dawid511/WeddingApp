import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AccountService } from '../_services/account.service';
import { CommonModule, NgIf, TitleCasePipe } from '@angular/common';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { Router, RouterLink, RouterLinkActive } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from '../_services/auth.service';
import { JwtHelperService } from '@auth0/angular-jwt';


@Component({
  selector: 'app-nav',
  standalone: true,
  imports: [FormsModule, BsDropdownModule, RouterLink, RouterLinkActive, TitleCasePipe, CommonModule],
  templateUrl: './nav.component.html',
  styleUrl: './nav.component.css'
})
export class NavComponent {
  accountService = inject(AccountService);
  authService = inject(AuthService);
  private router = inject(Router);
  private toastr = inject(ToastrService);
  model: any = {};
  showLoginForm = false;

  toggleLoginForm() {
  this.showLoginForm = !this.showLoginForm;
  }

  login() {
    this.accountService.login(this.model).subscribe({
      next: _ => {
      this.router.navigateByUrl('/home')
      },
      error: error => this.toastr.error(error.error)
    })
  }

  logout() {
    this.accountService.logout();
    this.router.navigateByUrl('/')
  }

  role: string | null = null;

  ngOnInit() {
    const token = localStorage.getItem('token');
    if (token) {
      try {
        const payload = JSON.parse(atob(token.split('.')[1]));
        this.role = (payload['role'] as string)?.toLowerCase() || null;
      } catch (e) {
        this.role = null;
      }
    }
  }
}

