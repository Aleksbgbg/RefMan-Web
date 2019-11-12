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
      this.sortByName(this._folders);
    }

    public addFile(file: File): void {
      this.setParent(file);
      this._files.push(file);
      this.sortByName(this._files);
    }

    private setParent(node: Node): void {
      node.parent = this;
    }

    private sortByName<T extends Node>(nodes: T[]): void {
      nodes.sort((a, b) => a.name.localeCompare(b.name));
    }
}