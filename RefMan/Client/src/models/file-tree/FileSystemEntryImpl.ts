import { NodeImpl } from "@/models/tree/NodeImpl";
import { FileSystemEntry } from "@/models/file-tree/FileSystemEntry";

export abstract class FileSystemEntryImpl extends NodeImpl implements FileSystemEntry {
  private _isEditing: boolean = false;

  public get existsInPersistentStore(): boolean {
    return this.id !== "0";
  }

  public get isEditing(): boolean {
    return this._isEditing;
  }

  public beginEditing(): void {
    this._isEditing = true;
  }

  public stopEditing(): void {
    this._isEditing = false;
  }
}