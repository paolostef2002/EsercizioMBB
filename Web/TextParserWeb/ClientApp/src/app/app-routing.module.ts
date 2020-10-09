import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DocumentTableComponent } from "./structure/documentTable.component"
import { DocumentFragmentsComponent } from "./structure/documentFragments.component";

const routes: Routes = [
  { path: "docs", component: DocumentTableComponent },
  { path: "fragments", component: DocumentFragmentsComponent },
  { path: "fragments/:id", component: DocumentFragmentsComponent },
  { path: "", component: DocumentTableComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
