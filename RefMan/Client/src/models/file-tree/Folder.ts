import { Branch } from "@/models/tree/Branch";
import { FileSystemEntry } from "@/models/file-tree/FileSystemEntry";
import { File } from "@/models/file-tree/File";

export interface Folder extends FileSystemEntry, Branch {
  addFolder(folder: Folder): void;

  addFile(file: File): void;

  addFolders(folders: Iterable<Folder>): void;

  addFiles(files: Iterable<File>): void;

  removeFolder(folder: Folder): void;

  removeFile(file: File): void;
}