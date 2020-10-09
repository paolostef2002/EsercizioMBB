import { Component } from '@angular/core';
import { Repository } from "../models/repository";
import { Fragment } from "../models/fragment.model";
import { Router, ActivatedRoute } from "@angular/router";

@Component({
  selector: "document-fragments",
  templateUrl: "documentFragments.component.html"
})

export class DocumentFragmentsComponent {

  constructor(private repo: Repository, router: Router, activeRoute: ActivatedRoute) {
    let id = Number.parseInt(activeRoute.snapshot.params["id"]);
    if (id) {
      this.repo.getDocument(id);
    } else {
      router.navigateByUrl("/");
    }
  }

  get fragments(): Fragment[] {
    return this.repo.document.fragments;
  }

}
