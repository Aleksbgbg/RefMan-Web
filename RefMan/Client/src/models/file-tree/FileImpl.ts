import { FileSystemEntryImpl } from "@/models/file-tree/FileSystemEntryImpl";
import { File } from "@/models/file-tree/File";

export class FileImpl extends FileSystemEntryImpl implements File {
  public static createNew(): FileImpl {
    return new FileImpl("0", "");
  }

  public static fromIdName(id: string, name: string): FileImpl {
    return new FileImpl(id, name);
  }

  public get isBranch(): boolean {
    return false;
  }
}