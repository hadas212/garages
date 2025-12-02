import { Component } from '@angular/core';
import { GarageSelectComponent } from './components/garage-select/garage-select.component';
import { GaragesTableComponent } from './components/garages-table/garages-table.component';
import { Garage } from './models/garage.model';
import { GaragesService } from './services/garages.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, GarageSelectComponent, GaragesTableComponent],
  template: `
    <app-garage-select (addSelected)="addSelectedGarages($event)"></app-garage-select>
    <app-garages-table [garages]="garagesInTable" [loading]="loading"></app-garages-table>
  `
})
export class AppComponent {
  garagesInTable: Garage[] = [];
  loading: boolean = false;

  constructor(private garagesService: GaragesService) {
    this.loadTable();
  }

  loadTable() {
    this.loading = true;
    this.garagesService.getGarages().subscribe(data => {
      this.garagesInTable = data;
      this.loading = false;
    });
  }

  addSelectedGarages(selected: Garage[]) {
    const newGarages = selected.filter(g =>
      !this.garagesInTable.some(t => t.id === g.id)
    );

    this.loading = true;
    let count = 0;

    newGarages.forEach(g => {
      this.garagesService.addGarage(g).subscribe(added => {
        this.garagesInTable.push(added);
        count++;
        if (count === newGarages.length) this.loading = false;
      });
    });

    if (newGarages.length === 0) this.loading = false;
  }
}
