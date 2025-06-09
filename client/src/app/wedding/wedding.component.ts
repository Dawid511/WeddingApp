import { Component, inject, EventEmitter, Output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { WeddingService } from '../_services/wedding.service';
import { ToastrService } from 'ngx-toastr';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';

@Component({
  selector: 'app-wedding',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './wedding.component.html',
  styleUrls: ['./wedding.component.css']
})
export class WeddingComponent {
  private weddingService = inject(WeddingService);
  private toastr = inject(ToastrService);
  private router = inject(Router);

  @Output() close = new EventEmitter<void>();

  model: any = {}
  // Metoda do stworzenia wesela
  createWedding() {
    if (!this.model.title || !this.model.weddingDate) {
      this.toastr.error('Podaj tytuł i datę wesela');
      return;
    }

    this.weddingService.createWedding(this.model).subscribe({
      next: (response) => {
        this.toastr.success('Wesele utworzone!');
        this.cancel(); 
      },
      error: (err) => this.toastr.error(err.error || 'Błąd podczas tworzenia wesela')
    });
  }

  cancel() {
    this.router.navigate(['/home']);
  }
}
