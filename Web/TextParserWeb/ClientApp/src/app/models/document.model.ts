import { Fragment } from "./fragment.model";

export class Document {

  constructor(
    public documentId?: number,
    public filename?: string,
    public originpath?: string,
    public content?: string,
    public importdate?: Date,
    public fragments?: Fragment[]) { }

}
