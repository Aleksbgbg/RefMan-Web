import { Node } from "./Node";
import { File } from "./File";
import { RootFolderResult } from "@/models/file-system/RootFolderResult";
import { FolderResult } from "@/models/file-system/FolderResult";

export class Folder extends Node {
    private _folders: Folder[];

    private _files: File[];

    private _canExpand: boolean;

    private _isExpanded: boolean = false;

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

    public static new(): Folder {
      return new Folder("0", "", false, [], []);
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

    public get isExpanded(): boolean {
      return this._isExpanded;
    }

    public get folders(): Folder[] {
      return this._folders;
    }

    public set folders(value: Folder[]) {
      this._folders = [];

      if (value.length === 0) {
        return;
      }

      this.addFolders(value);
    }

    public get files(): File[] {
      return this._files;
    }

    public set files(value: File[]) {
      this._files = [];

      if (value.length === 0) {
        return;
      }

      this.addFiles(value);
    }

    public allowExpansion(): void {
      this._canExpand = true;
    }

    public expand(): void {
      this.checkCanExpand();
      this._isExpanded = true;
    }

    public toggleExpansion(): void {
      this.checkCanExpand();
      this._isExpanded = !this._isExpanded;
    }

    public addFolders(folders: Folder[]): void {
      for (const folder of folders) {
        this.addFolderNoSort(folder);
      }
      this.sortFolders();
    }

    public addFiles(files: File[]): void {
      for (const file of files) {
        this.addFileNoSort(file);
      }
      this.sortFiles();
    }

    public addFolder(folder: Folder): void {
      this.addFolderNoSort(folder);
      this.sortFolders();
    }

    public addFile(file: File): void {
      this.addFileNoSort(file);
      this.sortFiles();
    }

    public sortFolders(): void {
      this.sortByName(this._folders);
    }

    public sortFiles(): void {
      this.sortByName(this._files);
    }

    public remove(node: Node): void {
      const removedFolder = this.removeNodeFromArray(node, this._folders);

      if (!removedFolder) {
        this.removeNodeFromArray(node, this._files);
      }

      if (this._files.length === 0 &&
          this._folders.length === 0) {
        this._canExpand = false;
      }
    }

    private checkCanExpand(): void {
      if (!this._canExpand) {
        throw new Error("Folder is not expandable but is being expanded");
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