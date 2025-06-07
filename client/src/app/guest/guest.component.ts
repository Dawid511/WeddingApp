import { Component, OnInit, inject } from '@angular/core';
import { Guest } from '../_modules/guest';
import { GuestService } from '../_services/guest.service';

@Component({
  selector: 'app-guest',
  templateUrl: './guest.component.html',
  styleUrls: ['./guest.component.css'],
  standalone: true,
  imports: []
})
export class GuestComponent implements OnInit {
  guests: Guest[] = [];
  private guestService = inject(GuestService);

  ngOnInit(): void {
    this.loadGuests();
  }

  loadGuests() {
    this.guestService.getGuests().subscribe({
      next: g => this.guests = g,
      error: err => console.error('Błąd ładowania gości:', err)
    });
  }

  deleteGuest(id: number) {
    this.guestService.deleteGuest(id).subscribe({
      next: () => this.guests = this.guests.filter(g => g.id !== id),
      error: err => console.error('Błąd usuwania gościa:', err)
    });
  }
}
