import { Component, inject, OnInit } from '@angular/core';
import { Vendor } from '../_modules/vendor';
import { VendorService } from '../_services/vendor.service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-vendor',
  imports: [FormsModule, CommonModule],
  templateUrl: './vendor.component.html',
  styleUrl: './vendor.component.css'
})

export class VendorComponent implements OnInit {
  vendors: Vendor[] = [];
  private vendorService = inject(VendorService);

  ngOnInit(): void {
    this.vendorService.getAll().subscribe(data => {
      this.vendors = data;
    });
  }

  filterCategory: string = '';

  get filteredVendors() {
    if (!this.filterCategory.trim()) return this.vendors;
    return this.vendors.filter(v =>
      v.category.toLowerCase().includes(this.filterCategory.toLowerCase())
    );
  }

  get uniqueCategories(): string[] {
  const categories = this.vendors.map(v => v.category);
  return Array.from(new Set(categories));
}


  getVendorImage(category: string): string {
  switch (category?.toLowerCase()) {
    case 'florist':
      return 'images/v1f.jpg';
    case 'dj':
      return 'images/v2d.jpg';
    case 'catering':
      return 'images/v3c.jpg';
    case 'photographer':
      return 'images/v4p.jpeg';
      case 'decorator':
      return 'images/v5d.jpeg';
    case 'clothes':
      return 'images/v6c.webp';
    default:
      return 'images/vdefault.jpg'; // zdjęcie domyślne
  }
}

}
