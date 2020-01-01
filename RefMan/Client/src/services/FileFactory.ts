import { FileTreeFactory } from "@/services/FileTreeFactory";
import { FileSystemEntry } from "@/models/file-tree/FileSystemEntry";
import { FileImpl } from "@/models/file-tree/FileImpl";

class FileFactory implements FileTreeFactory {
  public createPlaceholderNode(): FileSystemEntry {
    return FileImpl.createNew();
  }

  public createNodeFromIdAndName(id: string, name: string): FileSystemEntry {
    return FileImpl.fromIdName(id, name);
  }
}

export const fileFactory = new FileFactory();