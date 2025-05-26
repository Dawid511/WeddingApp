import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-lists',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './lists.component.html',
  styleUrls: ['./lists.component.css']
})
export class ListsComponent {
 newGuestName: string = '';
  newGuestCount: number = 1;

  guestList: Guest[] = [];

  addGuest() {
    const trimmedName = this.newGuestName.trim();
    if (trimmedName && this.newGuestCount > 0) {
      this.guestList.push({
        name: trimmedName,
        invited: false,
        confirmed: false,
        count: this.newGuestCount
      });
      this.resetForm();
    }
  }

  totalGuestCount(): number {
    return this.guestList.reduce((sum, guest) => sum + guest.count, 0);
  }

  resetForm() {
    this.newGuestName = '';
    this.newGuestCount = 1;
  }
}

interface Guest {
  name: string;
  invited: boolean;
  confirmed: boolean;
  count: number;
}