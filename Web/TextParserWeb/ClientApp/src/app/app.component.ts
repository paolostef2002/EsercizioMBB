import { Component } from '@angular/core';
import { Repository } from "./models/repository";
import { Document } from "./models/document.model";
import { Fragment } from "./models/fragment.model";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent {

  title = 'TextParserWeb';

  constructor(private repo: Repository) { }

  get document(): Document {
    return this.repo.document;
  }

  get documents(): Document[] {
    return this.repo.documents;
  }

  createDocument() {
    this.repo.createDocument(new Document(0, "filename", "originpath",
      "content", new Date("01012020"), null));
  }

  replaceDocument() {
    let p = this.repo.documents[0];
    p.filename = "Modified Product";
    p.importdate = new Date("01012020");
    this.repo.replaceDocument(p);
  }

  updateDocument() {
    let changes = new Map<string, any>();
    changes.set("filename", "filename");
    changes.set("fragments", null);
    this.repo.updateDocument(1, changes);
  }

  deleteDocument() {
    this.repo.deleteDocument(1);
  }

}
