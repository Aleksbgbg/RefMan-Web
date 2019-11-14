import { Node } from "./Node";
import { File } from "./File";

export class Folder extends Node {
    private readonly _folders: Folder[] = [];

    private readonly _files: File[] = [];

    public get isLeaf(): boolean {
      return false;
    }

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

    public remove(node: Node): void {
      const removedFolder = this.removeNodeFromArray(node, this._folders);

      if (!removedFolder) {
        this.removeNodeFromArray(node, this._files);
      }
    }

    private setParent(node: Node): void {
      node.parent = this;
    }

    private sortByName<T extends Node>(nodes: T[]): void {
      nodes.sort((a, b) => a.name.localeCompare(b.name));
    }

    private removeNodeFromArray<T extends Node>(node: Node, nodes: T[]): boolean {
      for (let index = 0; index < nodes.length; ++index) {
        if (nodes[index] === node) {
          nodes.splice(index, 1);
          return true;
        }
      }

      return false;
    }
}