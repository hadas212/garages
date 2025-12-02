import { Component, EventEmitter, Output, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';
import { MatButtonModule } from '@angular/material/button';
import { GaragesService } from '../../services/garages.service';
import { Garage } from '../../models/garage.model';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';

@Component({
  selector: 'app-garage-select',
  standalone: true,
  imports: [CommonModule, MatFormFieldModule, MatSelectModule, MatButtonModule,MatProgressSpinnerModule],
  templateUrl: './garage-select.component.html',
  styleUrls: ['./garage-select.component.css']
})
export class GarageSelectComponent {
  garages: Garage[] = [];
  selectedGarages: Garage[] = [];
  loading: boolean = false; 

  @Output() addSelected = new EventEmitter<Garage[]>();

  constructor(private garagesService: GaragesService) {
    this.loadGarages();
  }

  loadGarages() {
    this.loading = true; // עכשיו TypeScript מזהה את המשתנה
    this.garagesService.importFromGov().subscribe({
      next: data => {
        console.log('garages from gov:', data);
        this.garages = data;
        this.loading = false;
      },
      error: err => {
        console.error('Error loading garages from gov:', err);
        this.loading = false;
      }
    });
  }

  add() {
    this.addSelected.emit(this.selectedGarages);
    this.selectedGarages = [];
  }
}
