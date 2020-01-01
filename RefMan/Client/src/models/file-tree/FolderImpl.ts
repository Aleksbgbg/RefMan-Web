import { ReadonlyCollection } from "@/models/tree/ReadonlyCollection";
import { BranchImpl } from "@/models/tree/BranchImpl";
import { Branch } from "@/models/tree/Branch";
import { FileSystemEntryImpl } from "@/models/file-tree/FileSystemEntryImpl";
import { Leaf } from "@/models/tree/Leaf";
import { Folder } from "@/models/file-tree/Folder";
import { File } from "@/models/file-tree/File";
import { Node } from "@/models/tree/Node";

export class FolderImpl extends FileSystemEntryImpl implements Folder {
  private readonly _branch: BranchImpl;

  private readonly _canExpand: boolean;

  private constructor(id: string, name: string, canExpand: boolean) {
    super(id, name);
    this._branch = new BranchImpl(id, name);
    this._canExpand = canExpand;
  }

  public static createNew(): FolderImpl {
    return new FolderImpl("0", "", false);
  }

  public static fromIdName(id: string, name: string) {
    return new FolderImpl(id, name, false);
  }

  public static fromIdNameExpandable(id: string, name: string, canExpand: boolean) {
    return new FolderImpl(id, name, canExpand);
  }

  public get isBranch(): boolean {
    return true;
  }

  public get canExpand(): boolean {
    return this._canExpand || this._branch.canExpand;
  }

  public get isExpanded(): boolean {
    return this._branch.isExpanded;
  }

  public expand(): void {
    this._branch.expand();
  }

  public collapse(): void {
    this._branch.collapse();
  }

  public get branches(): ReadonlyCollection<Branch> {
    return this._branch.branches;
  }

  public get leaves(): ReadonlyCollection<Leaf> {
    return this._branch.leaves;
  }

  public addBranch(branch: Branch): void {
    this._branch.addBranch(branch);
  }

  public add(node: Node): void {
    this._branch.add(node);
  }

  public addLeaf(leaf: Leaf): void {
    this._branch.addLeaf(leaf);
  }

  public removeBranch(branch: Branch): void {
    this._branch.removeBranch(branch);
  }

  public remove(node: Node): void {
    this._branch.remove(node);
  }

  public removeLeaf(leaf: Leaf): void {
    this._branch.removeLeaf(leaf);
  }

  public addFolder(folder: Folder): void {
    this.addBranch(folder);
  }

  public addFile(file: File): void {
    this.addLeaf(file);
  }

  public addFolders(folders: Iterable<Folder>): void {
    for (const folder of folders) {
      this.addFolder(folder);
    }
  }

  public addFiles(files: Iterable<File>): void {
    for (const file of files) {
      this.addFile(file);
    }
  }

  public removeFolder(folder: Folder): void {
    this.removeBranch(folder);
  }

  public removeFile(file: File): void {
    this.removeLeaf(file);
  }
}