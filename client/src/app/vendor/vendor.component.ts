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
}
