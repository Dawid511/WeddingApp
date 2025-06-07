import { Component, inject } from '@angular/core';
import { Router } from '@angular/router';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-role',
  imports: [],
  templateUrl: './role.component.html',
  styleUrl: './role.component.css'
})
export class RoleComponent {
  private router = inject(Router);
  private accountService = inject(AccountService);

  selectRole(role: string) {
  const user = this.accountService.currentUser();
  if (!user) return;

  this.accountService.updateUserRole(user.id, role).subscribe({
    next: (updatedUser) => {
      if (role === 'User') {
        this.router.navigate(['/wedding']);
      } else if (role === 'Vendor') {
        this.router.navigate(['/vendor-add']);
      }
    },
    error: err => {
      console.error('Błąd aktualizacji roli:', err);
    }
  });
}

}