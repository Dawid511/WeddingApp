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
        'images/dekoracje3.jpg',
        'images/b1.jpg',
        'images/b2.jpg',
        'images/b3.jpg',
        'images/b4.jpg',
        'images/b5.jpg'
      ]
    },
    {
      name: 'Kwiaty',
      images: [
        'images/kwiaty1.jpg',
        'images/kwiaty2.jpg',
        'images/kwiaty3.jpg',
        'images/k1.webp',
        'images/k2.webp',
        'images/k3.jpg',
        'images/k4.jpg',
        'images/k5.jpg'
      ]
    },
    {
      name: 'Suknie ślubne',
      images: [
        'images/suknia1.jpg',
        'images/suknia2.webp',
        'images/suknia3.jpg',
        'images/suknia4.webp',
        'images/suknia5.webp',
        'images/suknia6.webp',
        'images/suknia7.webp',
        'images/suknia8.webp',
        'images/suknia9.webp',
        'images/suknia10.webp',
        'images/suknia11.webp',
        'images/suknia12.webp'
      ]
    }
    ,
    {
      name: 'Garnitury',
      images: [
        'images/garnitur1.jpg',
        'images/g1.webp',
        'images/garnitur2.jpg',
        'images/g2.webp',
        'images/g3.webp',
        'images/g4.webp',
        'images/g5.webp',
        'images/g6.webp'

      ]
    },
    {
      name: 'Zaproszenia',
      images: [
        'images/zaproszenie1.jpg',
        'images/zaproszenie2.jpg',
        'images/zaproszenie3.jpg',
        'images/z1.jpg',
        'images/z2.jpg',
        'images/z3.jpg',
        'images/z4.jpg',
        'images/z5.jpg',
        'images/z6.jpg',
        'images/z7.jpg',
        'images/z8.jpg'
      ]
    }
    ,
    {
      name: 'Winietki',
      images: [
        'images/winietka1.jpg',
        'images/winietka2.jpg',
        'images/winietka3.jpg',
        'images/w1.jpg',
        'images/w2.jpg',
        'images/w4.webp',
        'images/w5.webp',
        'images/w6.webp',
        'images/w7.jpg'

      ]
    }
    ,
    {
      name: 'Sesja ślubna',
      images: [
        'images/p1.jpg',
        'images/p2.jpg',
        'images/p3.jpg',
        'images/p4.jpg',
        'images/p6.jpg',
        'images/n1.jpg',
        'images/p7.jpg',
        'images/p8.jpg',
        'images/p9.jpg'

      ]
    },
    {
      name: 'Pomysły na zdjęcia',
      images: [
        'images/p5.jpg',
        'images/n2.jpg',
        'images/s1.jpg',
        'images/s4.jpg',
        'images/s5.jpg',
        'images/s6.jpg',
        'images/s7.jpg',
        'images/s8.jpg'

      ]
    }
  ];

  expandedCategories = new Set<string>();

  toggleCategory(name: string): void {
    if (this.expandedCategories.has(name)) {
      this.expandedCategories.delete(name);
    } else {
      this.expandedCategories.add(name);
    }
  }

  isExpanded(name: string): boolean {
    return this.expandedCategories.has(name);
  }

  slugify(name: string): string {
  return name.toLowerCase().replace(/\s+/g, '-').replace(/[^\w-]/g, '');
}


}

