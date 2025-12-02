import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatTableModule } from '@angular/material/table';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner'; // <-- ייבוא החסר
import { Garage } from '../../models/garage.model';

@Component({
  selector: 'app-garages-table',
  standalone: true,
  imports: [CommonModule, MatTableModule, MatProgressSpinnerModule],
  templateUrl: './garages-table.component.html',
  styleUrls: ['./garages-table.component.css']
})
export class GaragesTableComponent {
  @Input() garages: Garage[] = [];
  @Input() loading: boolean = false;

  // שמות העמודות שהטבלה תשתמש בהן
  displayedColumns: string[] = [
    'id','misparMosah','name','codSugMosah','sugMosah','address',
    'city','telephone','mikud','codMiktzoa','miktzoa','menahelMiktzoa',
    'licenseNumber','testime'
  ];
}

