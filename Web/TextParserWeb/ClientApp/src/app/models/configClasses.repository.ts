export class Filter {
  importdate?: string;
  search?: string;
  related: boolean = false;

  reset() {
    this.importdate = this.search = null;
    this.related = false;
  }
}
