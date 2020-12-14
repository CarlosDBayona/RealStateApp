import {Injectable} from '@angular/core';
import {environment} from '../../environments/environment';
import {HttpClient} from '@angular/common/http';
import {PropertyCharacteristic} from '../model/PropertyCharacteristic';
import {Observable} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PropertyCharacteristicService {
  apiUrl = environment.api + 'propertyCharacteristic/';

  constructor(private http: HttpClient) {
  }

  deleteRangePropertyCharacteristics(propertyCharacteristics: PropertyCharacteristic[]): Observable<any> {
    return this.http.post(this.apiUrl, propertyCharacteristics);
  }
}
