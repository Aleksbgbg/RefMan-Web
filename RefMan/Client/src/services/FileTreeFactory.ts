import { FileSystemEntry } from "@/models/file-tree/FileSystemEntry";

export interface FileTreeFactory {
  createPlaceholderNode(): FileSystemEntry;

  createNodeFromIdAndName(id: string, name: string): FileSystemEntry;
}