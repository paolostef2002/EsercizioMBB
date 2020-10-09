import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ModelModule } from "./models/model.module";
import { DocumentTableComponent } from "./structure/documentTable.component"
import { ImportDateFilterComponent } from "./structure/importdateFilter.component"
import { DocumentFragmentsComponent } from "./structure/documentFragments.component";

@NgModule({
  declarations: [AppComponent, DocumentTableComponent, ImportDateFilterComponent, DocumentFragmentsComponent],
  imports: [BrowserModule, AppRoutingModule, ModelModule],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
