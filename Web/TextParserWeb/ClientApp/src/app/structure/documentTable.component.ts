import { Component } from '@angular/core';
import { Repository } from "../models/repository";
import { Document } from "../models/document.model";
import { Router } from "@angular/router";

@Component({
  selector: "document-table",
  templateUrl: "./documentTable.component.html"
})

export class DocumentTableComponent {

  constructor(private repo: Repository, private router: Router) { }

  get documents(): Document[] {
    return this.repo.documents;
  }

  selectDocument(id: number) {
    this.repo.getDocument(id);
    this.router.navigateByUrl("/fragments");
  }

}

