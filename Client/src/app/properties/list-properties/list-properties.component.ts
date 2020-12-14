import {Component, OnInit} from '@angular/core';
import {PropertyService} from '../../_services/property.service';

@Component({
  selector: 'app-list-properties',
  templateUrl: './list-properties.component.html',
  styleUrls: ['./list-properties.component.scss']
})
export class ListPropertiesComponent implements OnInit {
  properties;

  constructor(private propertyService: PropertyService) {
  }

  ngOnInit(): void {
    this.getProperties();
  }

  getProperties(): void {
    this.propertyService.getAllProperties().subscribe(
      (data) => {
        this.properties = data;
      }
    );
  }

  deleteProperty(id: number): void{
    this.propertyService.deleteProperty(id).subscribe(
      () => {
        this.getProperties();
      }
    );
  }

}
