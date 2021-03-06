import { NodeResult } from "@/models/file-system/NodeResult";
import { FolderResult } from "@/models/file-system/FolderResult";

export interface RootFolderResult extends NodeResult {
  folders: FolderResult[];

  files: NodeResult[];
}