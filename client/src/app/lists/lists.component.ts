import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-lists',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './lists.component.html',
  styleUrl: './lists.component.css'
})
export class ListsComponent {
  newGuestName: string = '';
  newGuestStatus: boolean = true;

  guestList: { name: string; invited: boolean }[] = [];

  addGuest(): void {
    const trimmedName = this.newGuestName.trim();

    if (!trimmedName) {
      return; // Nie dodawaj pustych wpisów
    }

    this.guestList.push({
      name: trimmedName,
      invited: this.newGuestStatus
    });

    // Wyczyść pola formularza
    this.newGuestName = '';
    this.newGuestStatus = true;
  }
}
