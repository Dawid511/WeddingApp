import { Component, inject, input, output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { VendorService } from '../_services/vendor.service';
import { ToastrService } from 'ngx-toastr';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-vendor-add',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './vendor-add.component.html',
  styleUrls: ['./vendor-add.component.css']
})
export class VendorAddComponent {
  private vendorService = inject(VendorService);
  private toastr = inject(ToastrService);

  cancelAddVendor = output<boolean>();  

   categories: string[] = [
    'venue',
    'Catering',
    'Photographer',
    'Florist',
    'DJ',
    'Decorator',
    'clothes'
  ];

  model: any = {};

  addVendor() {
    this.vendorService.create(this.model).subscribe({
      next: response => {
        this.toastr.success('Vendor został dodany');
        this.cancel(); // zamknij formularz po sukcesie
      },
      error: error => this.toastr.error(error?.error || 'Wystąpił błąd')
    });
  }


  cancel() {
    this.cancelAddVendor.emit(false);
  }
}
