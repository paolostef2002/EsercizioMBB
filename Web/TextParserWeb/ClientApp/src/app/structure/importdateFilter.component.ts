import { Component } from '@angular/core';
import { Repository } from "../models/repository";
import { DatePipe } from '@angular/common'

@Component({
  selector: "importdate-filter",
  templateUrl: "importdateFilter.component.html"
})

export class ImportDateFilterComponent {

  private dp: DatePipe;

  constructor(private repo: Repository) { }

  setImportDateToday() {

    let latest_date = this.dp.transform(new Date(), 'dd/MM/yyyy');

    this.repo.filter.importdate = latest_date;
    this.repo.getDocuments();
  }

  setImportDateNull() {
    this.repo.filter.importdate = null;
    this.repo.getDocuments();
  }

  setImportDate(importdate: string) {
    this.repo.filter.importdate = importdate;
    this.repo.getDocuments();
  }
}
