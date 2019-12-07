import { NodeResult } from "@/models/file-system/NodeResult";

export interface FolderResult extends NodeResult {
  isExpandable: boolean;
}