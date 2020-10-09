import { Document } from "./document.model";

export class Fragment {

  constructor(
    public fragmentId?: number,
    public filename?: string,
    public identifier?: string,
    public rowIndex?: number,
    public destPath?: string,
    public text?: string,
    public document?: Document) { }

}
