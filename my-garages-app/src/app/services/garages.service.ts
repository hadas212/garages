import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Garage } from '../models/garage.model';

@Injectable({
  providedIn: 'root'
})
export class GaragesService {
  private apiUrl = 'http://localhost:5189/api/garages';

  constructor(private http: HttpClient) {}

  // שליפת כל המוסכים ממסד הנתונים
  getGarages(): Observable<Garage[]> {
    return this.http.get<Garage[]>(this.apiUrl);
  }

  // הוספת מוסך חדש למסד הנתונים
  addGarage(garage: Garage): Observable<Garage> {
    return this.http.post<Garage>(this.apiUrl, garage);
  }

  // שליפת מוסכים מה-API הממשלתי (למילוי Multi Select)
  importFromGov(): Observable<Garage[]> {
    return this.http.post<Garage[]>(`${this.apiUrl}/import`, {});
  }
}
