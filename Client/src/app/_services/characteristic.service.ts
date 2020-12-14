import {Injectable} from '@angular/core';
import {environment} from '../../environments/environment';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {Characteristic} from '../model/Characteristic';

@Injectable({
  providedIn: 'root'
})
export class CharacteristicService {
  apiUrl = environment.api + 'characteristic/';

  constructor(private http: HttpClient) {
  }

  getAllCharacteristics(): Observable<Characteristic[]> {
    return this.http.get<Characteristic[]>(this.apiUrl);
  }
}
