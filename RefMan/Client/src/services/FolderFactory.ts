import { FileTreeFactory } from "@/services/FileTreeFactory";
import { FileSystemEntry } from "@/models/file-tree/FileSystemEntry";
import { FolderImpl } from "@/models/file-tree/FolderImpl";

class FolderFactory implements FileTreeFactory {
  public createPlaceholderNode(): FileSystemEntry {
    return FolderImpl.createNew();
  }

  public createNodeFromIdAndName(id: string, name: string): FileSystemEntry {
    return FolderImpl.fromIdName(id, name);
  }
}

export const folderFactory = new FolderFactory();