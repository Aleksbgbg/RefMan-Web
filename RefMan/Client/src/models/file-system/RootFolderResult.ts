import { NodeResult } from "@/models/file-system/NodeResult";

export interface RootFolderResult extends NodeResult {
  folders: NodeResult[];

  files: NodeResult[];
}