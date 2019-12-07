import { FolderResult } from "@/models/file-system/FolderResult";
import { NodeResult } from "@/models/file-system/NodeResult";

export interface ExpandFolderResult {
  folders: FolderResult[];

  files: NodeResult[];
}