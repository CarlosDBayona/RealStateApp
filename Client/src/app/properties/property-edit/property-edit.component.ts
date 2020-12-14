import {Component, OnInit} from '@angular/core';
import {Property} from '../../model/Property';
import {Characteristic} from '../../model/Characteristic';
import {CharacteristicService} from '../../_services/characteristic.service';
import {PropertyService} from '../../_services/property.service';
import {ActivatedRoute, Params, Router, RouterLink, RouterLinkActive} from '@angular/router';
import {PropertyCharacteristicService} from '../../_services/property-characteristic.service';

@Component({
  selector: 'app-property-create',
  templateUrl: './property-edit.component.html',
  styleUrls: ['./property-edit.component.scss']
})
export class PropertyEditComponent implements OnInit {
  characteristics: Characteristic[] = [];
  property: Partial<Property> = {
    propertyCharacteristics: []
  };
  deletedPropertyCharacteristics = [];

  constructor(private characteristicService: CharacteristicService, private  propertyService: PropertyService,
              private route: ActivatedRoute, private propertyCharacteristicService: PropertyCharacteristicService,
              private router: Router) {
  }

  ngOnInit(): void {
    this.getCharacteristics();
    this.route.params.subscribe(
      (params: Params) => {
        const id = +params.id;
        this.getProperty(id);
      }
    );
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

  private getProperty(id: number): void {
    this.propertyService.getProperty(id).subscribe(
      (property) => {
        this.property = property;

      }
    );
  }

  updateProperty(): void {
    this.propertyService.updateProperty(this.property).subscribe(
      () => {
        if (this.deletedPropertyCharacteristics.length > 0) {
          this.updateCharacteristics();
        }
        this.router.navigateByUrl('/');
      }
    );
  }

  updateCharacteristics(): void {
    this.propertyCharacteristicService.deleteRangePropertyCharacteristics(this.deletedPropertyCharacteristics).subscribe();
  }

  deletePropertyCharacteristic(index: number): void {
    const propertyCharacteristic = this.property.propertyCharacteristics.splice(index, 1)[0];

    if (propertyCharacteristic.id) {
      this.deletedPropertyCharacteristics.push(propertyCharacteristic);
    }
  }
}
