import { Document } from "./document.model";
import { Fragment } from "./fragment.model";
import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Filter } from "./configClasses.repository";

const documentsUrl = "/api/documents";
const fragmentsUrl = "/api/fragments";

@Injectable()
export class Repository {

  document: Document;
  documents: Document[];
  fragments: Fragment[] = [];
  filter: Filter = new Filter();

  constructor(private http: HttpClient) {
    this.filter.related = true;
    this.getDocuments();
  }

  getDocument(id: number) {
    this.http.get<Document>(`${documentsUrl}/${id}`)
      .subscribe(p => this.document = p);
  }

  getDocuments() {
    let url = `${documentsUrl}?related=${this.filter.related}`;
    if (this.filter.importdate) {
      url += `&importdate=${this.filter.importdate}`;
    }
    if (this.filter.search) {
      url += `&search=${this.filter.search}`;
    }
    this.http.get<Document[]>(url).subscribe(docs => this.documents = docs);
  }

  getFragments() {
    this.http.get<Fragment[]>(fragmentsUrl)
      .subscribe(frags => this.fragments = frags);
  }

  createDocument(doc: Document) {
    let data = {
      filename: doc.filename, originpath: doc.originpath,
      content: doc.content, importdate: doc.importdate
    };
    this.http.post<number>(documentsUrl, data)
      .subscribe(id => {
        doc.documentId = id;
        this.documents.push(doc);
      });
  }


  replaceDocument(doc: Document) {
    let data = {
      filename: doc.filename, originpath: doc.originpath,
      content: doc.content, importdate: doc.importdate
    };
    this.http.put(`${documentsUrl}/${doc.documentId}`, data)
      .subscribe(() => this.getDocuments());
  }


  updateDocument(id: number, changes: Map<string, any>) {
    let patch = [];
    changes.forEach((value, key) =>
      patch.push({ op: "replace", path: key, value: value }));
    this.http.patch(`${documentsUrl}/${id}`, patch)
      .subscribe(() => this.getDocuments());
  }

  deleteDocument(id: number) {
    this.http.delete(`${documentsUrl}/${id}`)
      .subscribe(() => this.getDocuments());
  }


}
