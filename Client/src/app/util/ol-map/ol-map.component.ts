import {AfterViewInit, Component, ElementRef, Input, OnInit} from '@angular/core';
import Map from 'ol/Map';
import View from 'ol/View';
import TileLayer from 'ol/layer/Tile';
import XYZ from 'ol/source/XYZ';
import * as Proj from 'ol/proj';
import {defaults as defaultControls} from 'ol/control';
import {OSM} from 'ol/source';
import VectorLayer from 'ol/layer/Vector';
import {Circle, Fill, Style} from 'ol/style';
import {Point} from 'ol/geom';
import VectorSource from 'ol/source/Vector';
import {Feature} from 'ol';

export const DEFAULT_HEIGHT = '500px';
export const DEFAULT_WIDTH = '500px';
export const DEFAULT_LAT = 0;
export const DEFAULT_LON = 0;

@Component({
  selector: 'app-ol-map',
  templateUrl: './ol-map.component.html',
  styleUrls: ['./ol-map.component.scss']
})
export class OlMapComponent implements OnInit, AfterViewInit {
  @Input() lat: number = DEFAULT_LAT;
  @Input() lon: number = DEFAULT_LON;
  @Input() zoom: number;

  target: string = 'map-' + Math.random().toString(36).substring(2);
  map: Map;

  private mapEl: HTMLElement;

  constructor(private elementRef: ElementRef) { }

  ngOnInit(): void {
  }

  ngAfterViewInit(): void {
    this.mapEl = this.elementRef.nativeElement.querySelector('#' + this.target);
    const point = new Point(Proj.fromLonLat([this.lon, this.lat]));
    this.map = new Map({
      target: this.target,
      layers: [
        new TileLayer({
          source: new OSM()
        }),
        new VectorLayer({
          source: new VectorSource({
            features: [new Feature(point)],
          }),
          style: new Style({
            image: new Circle({
              radius: 9,
              fill: new Fill({color: 'red'}),
            }),
          }),
        }),
      ],
      view: new View({
        center: Proj.fromLonLat([this.lon, this.lat]),
        zoom: this.zoom
      }),
      controls: [],
      interactions: []
    });
  }

}
