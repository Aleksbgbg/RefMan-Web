import { Node } from "./Node";
import { File } from "./File";
import { RootFolderResult } from "@/models/file-system/RootFolderResult";
import { NodeResult } from "@/models/file-system/NodeResult";

export class Folder extends Node {
    private readonly _folders: Folder[];

    private readonly _files: File[];

    constructor(id: number, name: string, folders: Folder[], files: File[]) {
      super(id, name);

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
        rootFolderResult.id,
        rootFolderResult.name,
        rootFolderResult.folders.map(Folder.fromNodeResult),
        rootFolderResult.files.map(File.fromNodeResult)
      );
    }

    public static fromNodeResult(nodeResult: NodeResult): Folder {
      return new Folder(nodeResult.id, nodeResult.name, [], []);
    }

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