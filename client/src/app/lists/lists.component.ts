// import { CommonModule } from '@angular/common';
// import { Component, inject, OnInit } from '@angular/core';
// import { FormsModule } from '@angular/forms';
// import { GuestList } from '../_modules/guest-list';
// import { GuestListService } from '../_services/guest-list.service';

// @Component({
//   selector: 'app-lists',
//   standalone: true,
//   imports: [FormsModule, CommonModule],
//   templateUrl: './lists.component.html',
//   styleUrls: ['./lists.component.css']
// })

// export class ListsComponent implements OnInit {
//   guestLists: GuestList[] = [];
//   private guestListService = inject(GuestListService);

//   ngOnInit(): void {
//     this.loadGuestLists();
//   }

//   loadGuestLists() {
//     this.guestListService.getGuestLists().subscribe({
//       next: lists => this.guestLists = lists,
//       error: err => console.error('Błąd ładowania list gości:', err)
//     });
//   }

//   deleteList(id: number) {
//     this.guestListService.deleteGuestList(id).subscribe({
//       next: () => this.guestLists = this.guestLists.filter(l => l.id !== id),
//       error: err => console.error('Błąd usuwania listy:', err)
//     });
//   }
// }


// import { Component, inject, OnInit } from '@angular/core';
// import { GuestList } from '../_modules/guest-list';
// import { Guest } from '../_modules/guest';
// import { GuestListService } from '../_services/guest-list.service';
// import { GuestService } from '../_services/guest.service';
// import { FormsModule } from '@angular/forms';
// import { CommonModule } from '@angular/common';

// @Component({
//   selector: 'app-lists',
//   templateUrl: './lists.component.html',
//   imports: [FormsModule, CommonModule],
//   styleUrls: ['./lists.component.css']
// })
// export class ListsComponent implements OnInit {
//   guestLists: GuestList[] = [];
//   private guestListService = inject(GuestListService);
//   private guestService = inject(GuestService);

//   // Do formularza dodawania gości: dynamiczne pola po ID listy
//   newGuestName: { [key: number]: string } = {};
//   newGuestEmail: { [key: number]: string } = {};
//   newGuestPhone: { [key: number]: string } = {};
//   newGuestCount: { [key: number]: number } = {};
//   newGuestStatus: { [key: number]: string } = {};

//   ngOnInit(): void {
//     this.loadGuestLists();
//   }

//   loadGuestLists() {
//     this.guestListService.getGuestLists().subscribe({
//       next: lists => this.guestLists = lists,
//       error: err => console.error('Błąd ładowania list gości:', err)
//     });
//   }

//   deleteList(id: number) {
//     this.guestListService.deleteGuestList(id).subscribe({
//       next: () => this.guestLists = this.guestLists.filter(l => l.id !== id),
//       error: err => console.error('Błąd usuwania listy:', err)
//     });
//   }

//   // Dodanie nowego gościa do listy
//   addGuestToList(listId: number) {
//     const newGuest: Guest = {
//       id: 0, // backend przypisze
//       guestListId: listId,
//       fullName: this.newGuestName[listId],
//       count: this.newGuestCount[listId] || 1,
//       status: this.newGuestStatus[listId] || 'Invited',
//       notes: '',
//     };

//     this.guestService.addGuest(newGuest).subscribe({
//       next: guest => {
//         // Dodajemy gościa lokalnie do listy
//         const list = this.guestLists.find(l => l.id === listId);
//         if (list) {
//           list.guests.push(guest);
//         }

//         // Czyścimy pola
//         this.newGuestName[listId] = '';
//         this.newGuestEmail[listId] = '';
//         this.newGuestPhone[listId] = '';
//         this.newGuestCount[listId] = 1;
//         this.newGuestStatus[listId] = 'Invited';
//       },
//       error: err => console.error('Błąd dodawania gościa:', err)
//     });
//   }

//   // Edycja gościa
//   editGuest(guest: Guest) {
//     guest['editing'] = true;
//   }

//   cancelEdit(guest: Guest) {
//     guest['editing'] = false;
//     // opcjonalnie: reload danych gościa z backendu aby cofnąć zmiany
//   }

//   saveGuest(list: GuestList, guest: Guest) {
//     this.guestService.updateGuest(guest).subscribe({
//       next: () => {
//         guest['editing'] = false;
//       },
//       error: err => console.error('Błąd zapisu gościa:', err)
//     });
//   }

//   deleteGuest(list: GuestList, guestId: number) {
//     this.guestService.deleteGuest(guestId).subscribe({
//       next: () => {
//         list.guests = list.guests.filter(g => g.id !== guestId);
//       },
//       error: err => console.error('Błąd usuwania gościa:', err)
//     });
//   }
// }


import { Component, OnInit } from '@angular/core';
// import { GuestList } from '../_modules/guest-list';
// import { GuestService } from '../_services/guest.service';
// import { GuestComponent } from "../guest/guest.component";
// import { FormControl } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-list',
  templateUrl: './lists.component.html',
  imports: [ CommonModule]
})
export class ListsComponent  {}
//   guestLists: GuestList[] = [];

//   constructor(private guestService: GuestService) {}

//   ngOnInit() {
//     this.guestService.getGuestLists().subscribe(data => {
//       this.guestLists = data;
//     });
//   }

//   addGuestToList(listId: number) {
//     const newGuest = {
//       id: 0,
//       fullName: 'Nowy Gość',
//       status: 'pending',
//       count: 1
//     };

//     this.guestService.addGuest(listId, newGuest).subscribe(updatedList => {
//       const index = this.guestLists.findIndex(l => l.id === listId);
//       if (index > -1) {
//         this.guestLists[index] = updatedList;
//       }
//     });
//   }
// }
