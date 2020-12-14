import {Component, OnInit} from '@angular/core';
import {Property} from '../../model/Property';
import {Characteristic} from '../../model/Characteristic';
import {CharacteristicService} from '../../_services/characteristic.service';
import {PropertyService} from '../../_services/property.service';
import {Router} from '@angular/router';

@Component({
  selector: 'app-property-create',
  templateUrl: './property-create.component.html',
  styleUrls: ['./property-create.component.scss']
})
export class PropertyCreateComponent implements OnInit {
  characteristics: Characteristic[] = [];
  property: Partial<Property> = {
    propertyCharacteristics: []
  };

  constructor(private characteristicService: CharacteristicService, private  propertyService: PropertyService, private router:Router) {
  }

  ngOnInit(): void {
    this.getCharacteristics();
  }

  getCharacteristics(): void {
    this.characteristicService.getAllCharacteristics().subscribe(
      (characteristics) => {
        this.characteristics = characteristics;
      }
    );
  }

  addCharacteristic(characteristicTypeId: number, characteristicId: string): void {
    const characteristic = this.characteristics[+characteristicId];
    this.property.propertyCharacteristics.push({
      characteristicId: characteristic.id,
      characteristicTypeId,
      characteristicName: characteristic.name
    });
  }

  createProperty(): void {
    this.propertyService.addProperty(this.property).subscribe(
      () => {
        this.router.navigateByUrl('/');
      }
    );
  }

  deletePropertyCharacteristic(i: number): void {
    this.property.propertyCharacteristics.splice(i, 1);
  }
}
