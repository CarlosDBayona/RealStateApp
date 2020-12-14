import {BrowserModule} from '@angular/platform-browser';
import {NgModule} from '@angular/core';

import {AppRoutingModule} from './app-routing.module';
import {AppComponent} from './app.component';
import {HeaderComponent} from './header/header.component';
import {ListPropertiesComponent} from './properties/list-properties/list-properties.component';
import {HTTP_INTERCEPTORS, HttpClientModule} from '@angular/common/http';
import {PropertyDetailComponent} from './properties/property-detail/property-detail.component';
import {NgxGalleryModule} from '@kolkov/ngx-gallery';
import {TabsModule} from 'ngx-bootstrap/tabs';
import {OlMapComponent} from './util/ol-map/ol-map.component';
import {PropertyCreateComponent} from './properties/property-create/property-create.component';
import {FormsModule} from '@angular/forms';
import {PropertyEditComponent} from './properties/property-edit/property-edit.component';
import { OnlyNumberDirective } from './_directives/only-number.directive';
import {NgxSpinnerModule} from 'ngx-spinner';
import {LoadingInterceptor} from './_interceptiors/loading.interceptor';
import {ErrorInterceptor} from './_interceptiors/error.interceptor';
import {ToastrModule} from 'ngx-toastr';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import { NotFoundComponent } from './errors/not-found/not-found.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    ListPropertiesComponent,
    PropertyDetailComponent,
    OlMapComponent,
    PropertyCreateComponent,
    PropertyEditComponent,
    OnlyNumberDirective,
    NotFoundComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    NgxGalleryModule,
    TabsModule.forRoot(),
    FormsModule,
    NgxSpinnerModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot({
      positionClass: 'toast-bottom-right'
    }),
  ],
  providers: [
    {provide: HTTP_INTERCEPTORS, useClass: LoadingInterceptor, multi: true},
    {provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true},

  ],
  bootstrap: [AppComponent]
})
export class AppModule {
}
