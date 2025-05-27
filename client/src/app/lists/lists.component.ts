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
    const trimmedName = this.newGuestName.trim(); //usuwanie białych znaków
    if (trimmedName && this.newGuestCount > 0) {
      this.guestList.push({
        name: trimmedName,
        invited: false,
        confirmed: false,
        editing: false, 
        count: this.newGuestCount
      });
      this.resetForm();
    }
  }

  //licznik całościowej sumy gości
  totalGuestCount(): number {
    return this.guestList.reduce((sum, guest) => sum + guest.count, 0);
  }

  resetForm() {
    this.newGuestName = '';
    this.newGuestCount = 1;
  }

  //usuwanie gości
  deleteGuestList(index: number) {
    this.guestList.splice(index, 1);
  }

  //edytowanie gości
  editGuestList(index: number) {
    this.guestList[index].editing = true;
  }

  //zapisywanie zmian po edytowaniu
  saveGuestList(index: number, newText: string) {
    if (newText.trim()) {
      this.guestList[index].name = newText.trim();
      this.guestList[index].editing = false;
    }
  }
}


interface Guest {
  name: string;
  invited: boolean;
  confirmed: boolean;
  editing: boolean;
  count: number;
}