import {Component, OnInit} from '@angular/core';
import {PropertyService} from '../../_services/property.service';
import {ActivatedRoute, Params} from '@angular/router';
import {Property} from '../../model/Property';
import {NgxGalleryAnimation, NgxGalleryImage, NgxGalleryOptions} from '@kolkov/ngx-gallery';

@Component({
  selector: 'app-property-detail',
  templateUrl: './property-detail.component.html',
  styleUrls: ['./property-detail.component.scss']
})
export class PropertyDetailComponent implements OnInit {
  property: Partial<Property> = {
    propertyCharacteristics: []
  };
  galleryOptions: NgxGalleryOptions[];
  galleryImages: NgxGalleryImage[];

  constructor(private propertyService: PropertyService, private route: ActivatedRoute) {
  }

  ngOnInit(): void {
    this.route.params.subscribe(
      (params: Params) => {
        const id = +params.id;
        this.getProperty(id);
      }
    );

    this.galleryOptions = [
      {
        width: '500px',
        height: '500px',
        imagePercent: 100,
        thumbnailsColumns: 4,
        imageAnimation: NgxGalleryAnimation.Slide,
        preview: false
      }
    ];
    this.galleryImages = this.getImages();
  }

  getImages(): NgxGalleryImage[] {
    const imageUrls = [];
    imageUrls.push({
      small: 'https://loremflickr.com/cache/resized/3190_3038596225_78d39039db_c_600_600_nofilter.jpg',
      medium: 'https://loremflickr.com/cache/resized/3190_3038596225_78d39039db_c_600_600_nofilter.jpg',
      big: 'https://loremflickr.com/cache/resized/3190_3038596225_78d39039db_c_600_600_nofilter.jpg'
    });
    imageUrls.push({
      small: 'https://loremflickr.com/cache/resized/3146_3038600725_eaed69f3f4_c_600_600_nofilter.jpg',
      medium: 'https://loremflickr.com/cache/resized/3146_3038600725_eaed69f3f4_c_600_600_nofilter.jpg',
      big: 'https://loremflickr.com/cache/resized/3146_3038600725_eaed69f3f4_c_600_600_nofilter.jpg1'
    });
    imageUrls.push({
      small: 'https://loremflickr.com/cache/resized/3162_3039464394_b3226c9a77_c_600_600_nofilter.jpg',
      medium: 'https://loremflickr.com/cache/resized/3162_3039464394_b3226c9a77_c_600_600_nofilter.jpg',
      big: 'https://loremflickr.com/cache/resized/3162_3039464394_b3226c9a77_c_600_600_nofilter.jpg'
    });
    return imageUrls;
  }

  getProperty(id: number): void {
    this.propertyService.getProperty(id).subscribe(
      (property) => {
        this.property = property;
      }
    );
  }
}
