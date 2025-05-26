import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-inspirations',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './inspirations.component.html',
  styleUrl: './inspirations.component.css'
})
export class InspirationsComponent {

  inspirations = [
    {
      name: 'Dekoracje',
      images: [
        'images/dekoracje1.jpg',
        'images/dekoracje2.jpg',
        'images/dekoracje3.jpg'
      ]
    },
    {
      name: 'Zaproszenia',
      images: [
        'images/zaproszenie1.jpg',
        'images/zaproszenie2.jpg',
        'images/zaproszenie3.jpg'
      ]
    },
    {
      name: 'Kwiaty',
      images: [
        'images/kwiaty1.jpg',
        'images/kwiaty2.jpg',
        'images/kwiaty3.jpg'
      ]
    },
    {
      name: 'Suknie ślubne',
      images: [
        'images/suknia1.jpg',
        'images/suknia2.jpg',
        'images/suknia3.jpg'
      ]
    }
    ,
    {
      name: 'Garnitury',
      images: [
        'images/garnitur1.jpg',
        'images/garnitur2.jpg',
        'images/garnitur3.jpg'
      ]
    }
    ,
    {
      name: 'Winietki',
      images: [
        'images/winietka1.jpg',
        'images/winietka2.jpg',
        'images/winietka3.jpg'
      ]
    }
  ];
}

