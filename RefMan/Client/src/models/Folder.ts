import { Node } from "./Node";
import { File } from "./File";

export class Folder extends Node {
    private readonly _folders: Folder[] = [];

    private readonly _files: File[] = [];

    public get folders(): Folder[] {
      return this._folders;
    }

    public get files(): File[] {
      return this._files;
    }

    public addFolder(folder: Folder): void {
      this.setParent(folder);
      this._folders.push(folder);
    }

    public addFile(file: File): void {
      this.setParent(file);
      this._files.push(file);
    }

    private setParent(node: Node): void {
      node.parent = this;
    }
}