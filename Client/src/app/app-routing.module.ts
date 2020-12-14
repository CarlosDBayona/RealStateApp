import {NgModule} from '@angular/core';
import {Routes, RouterModule} from '@angular/router';
import {ListPropertiesComponent} from './properties/list-properties/list-properties.component';
import {PropertyDetailComponent} from './properties/property-detail/property-detail.component';
import {PropertyCreateComponent} from './properties/property-create/property-create.component';
import {PropertyEditComponent} from './properties/property-edit/property-edit.component';
import {NotFoundComponent} from './errors/not-found/not-found.component';

const routes: Routes = [
  {path: '', component: ListPropertiesComponent},
  {path: 'property/view/:id', component: PropertyDetailComponent},
  {path: 'create', component: PropertyCreateComponent},
  {path: 'property/edit/:id', component: PropertyEditComponent},
  {path: '**', component: NotFoundComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
