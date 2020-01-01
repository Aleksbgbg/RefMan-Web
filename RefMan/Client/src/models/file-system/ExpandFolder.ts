import { Folder } from "@/models/file-tree/Folder";
import { File } from "@/models/file-tree/File";

export interface ExpandFolder {
  folders: Folder[];

  files: File[];
}