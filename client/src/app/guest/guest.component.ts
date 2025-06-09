import { Component, OnInit } from '@angular/core';
import { GuestService } from '../_services/guest.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-guest',
  standalone: true,
    imports: [CommonModule, FormsModule],
    templateUrl: './guest.component.html',
    styleUrl: './guest.component.css'
})
export class GuestComponent implements OnInit {
  guests: any[] = [];
  newFullName: string = '';
  newCount: number = 1;

  constructor(private guestService: GuestService) {}

  ngOnInit(): void {
    this.loadGuests();
  }

  loadGuests(): void {
    this.guestService.getGuests().subscribe({
      next: (data) => (this.guests = data),
      error: (err) => console.error('Błąd ładowania gości:', err)
    });
  }

  addGuest(): void {
    if (!this.newFullName || this.newCount <= 0) return;

    this.guestService.addGuest(this.newFullName, this.newCount).subscribe({
      next: () => {
        this.newFullName = '';
        this.newCount = 1;
        this.loadGuests();
      },
      error: (err) => console.error('Błąd dodawania gościa:', err)
    });
  }

  deleteGuest(id: number): void {
    this.guestService.deleteGuest(id).subscribe({
      next: () => this.loadGuests(),
      error: (err) => console.error('Błąd usuwania gościa:', err)
    });
  }

  editGuest(index: number): void {
  this.guests[index].editing = true;
}

saveGuest(index: number): void {
  const guest = this.guests[index];
  guest.editing = false;
}

totalGuestCount(): number {
  return this.guests.reduce((sum, guest) => sum + (guest.count || 0), 0);
}


updateGuest(index: number): void {
  console.log('Zmieniono status gościa:', this.guests[index]);
}
}
