
// import { Component } from '@angular/core';
// import { Router } from '@angular/router';
// import { AuthService } from '../_services/auth.service';
// import { HttpHeaders } from '@angular/common/http';

// @Component({
//   selector: 'app-role',
//   templateUrl: './role.component.html',
//   styleUrls: ['./role.component.css']
// })
// export class RoleComponent {

//   constructor(
//     private authService: AuthService,
//     private router: Router
//   ) {}

//   setRole(role: 'User' | 'Vendor') {
//   this.authService.setUserRole(role).subscribe({
//     next: (response) => {
//       console.log('Rola ustawiona:', role);

//       const userJson = localStorage.getItem('user');
//       if (userJson) {
//         const user = JSON.parse(userJson);
//         console.log('Aktualny użytkownik:', user);
//       }
//       if (role === 'User') {
//         this.router.navigate(['/wedding']);
//       } else if (role === 'Vendor') {
//         this.router.navigate(['/vendor-add']);
//       }
//     },
//     error: err => console.error('Błąd ustawiania roli:', err)
//   });
// }
// }


import { Component } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { AuthService } from '../_services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-role',
  templateUrl: './role.component.html',
  styleUrls: ['./role.component.css']

})
export class RoleComponent {

  constructor(
    private http: HttpClient,
    private authService: AuthService,
    private router: Router
  ) {}

  setRole(role: 'User' | 'Vendor') {
    const token = this.authService.getToken();
    if (!token) {
      console.error('Brak tokena!');
      return;
    }

    const headers = new HttpHeaders({
      'Authorization': `Bearer ${token}`
    });

    const body = { role };

    this.http.post('https://localhost:5001/api/account/set-role', body, { headers }).subscribe({
      next: () => {
         if (role === 'User') {
        this.router.navigate(['/wedding']);
      } else if (role === 'Vendor') {
        this.router.navigate(['/vendor-add']);
      }
      },
      error: err => console.error('Błąd ustawiania roli:', err)
    });
  }
}