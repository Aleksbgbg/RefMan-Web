import { Node } from "./Node";
import { File } from "./File";
import { RootFolderResult } from "@/models/file-system/RootFolderResult";
import { FolderResult } from "@/models/file-system/FolderResult";

export class Folder extends Node {
    private _folders: Folder[];

    private _files: File[];

    private _canExpand: boolean;

    constructor(id: string, name: string, canExpand: boolean, folders: Folder[], files: File[]) {
      super(id, name);

      this._canExpand = canExpand;

      this._folders = folders;
      this._files = files;

      for (const folder of this._folders) {
        this.setParent(folder);
      }

      for (const file of this._files) {
        this.setParent(file);
      }
    }

    public static fromRootFolderResult(rootFolderResult: RootFolderResult): Folder {
      return new Folder(
        rootFolderResult.idString,
        rootFolderResult.name,
        true,
        rootFolderResult.folders.map(Folder.fromFolderResult),
        rootFolderResult.files.map(File.fromNodeResult)
      );
    }

    public static fromFolderResult(folderResult: FolderResult): Folder {
      return new Folder(
        folderResult.idString,
        folderResult.name,
        folderResult.isExpandable,
        [],
        []
      );
    }

    public get isLeaf(): boolean {
      return false;
    }

    public get canExpand(): boolean {
      return this._canExpand;
    }

    public get folders(): Folder[] {
      return this._folders;
    }

    public set folders(value: Folder[]) {
      this._folders = [];

      if (value.length === 0) {
        return;
      }

      for (const folder of value) {
        this.addFolderNoSort(folder);
      }
      this.sortByName(this._folders);
    }

    public get files(): File[] {
      return this._files;
    }

    public set files(value: File[]) {
      this._files = [];

      if (value.length === 0) {
        return;
      }

      for (const file of value) {
        this.addFileNoSort(file);
      }
      this.sortByName(this._files);
    }

    public addFolder(folder: Folder): void {
      this.addFolderNoSort(folder);
      this.sortByName(this._folders);
    }

    public addFile(file: File): void {
      this.addFileNoSort(file);
      this.sortByName(this._files);
    }

    public remove(node: Node): void {
      const removedFolder = this.removeNodeFromArray(node, this._folders);

      if (!removedFolder) {
        this.removeNodeFromArray(node, this._files);
      }
    }

    private addFolderNoSort(folder: Folder): void {
      this.setParent(folder);
      this._folders.push(folder);
    }

    private addFileNoSort(file: File): void {
      this.setParent(file);
      this._files.push(file);
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