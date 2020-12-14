import {PropertyCharacteristic} from './PropertyCharacteristic';

export interface Property {
  latitude: number;
  longitude: number;
  name: string;
  price: number;
  ownerName: string;
  ownerPhone: string;
  description: string;
  area: number;
  createdAt: Date;
  rooms: number;
  bathrooms: number;
  propertyCharacteristics: PropertyCharacteristic[];
}
