import {Injectable} from '@angular/core';
import {environment} from '../../environments/environment';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {Property} from '../model/Property';

@Injectable({
  providedIn: 'root'
})
export class PropertyService {
  apiUrl = environment.api + 'property/';

  constructor(private http: HttpClient) {
  }

  getAllProperties(): Observable<Property[]> {
    return this.http.get<Property[]>(this.apiUrl);
  }

  getProperty(id: number): Observable<Property> {
    return this.http.get<Property>(this.apiUrl + id);
  }

  addProperty(property: Partial<Property>): Observable<any> {
    return this.http.post(this.apiUrl, property);
  }

  updateProperty(property: Partial<Property>): Observable<any> {
    return this.http.put(this.apiUrl, property);
  }

  deleteProperty(id: number): Observable<any> {
    return this.http.delete(this.apiUrl + id);
  }
}
