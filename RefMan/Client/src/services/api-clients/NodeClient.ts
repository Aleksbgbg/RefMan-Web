import { NodeResult } from "@/models/file-system/NodeResult";
import { EntryCreation } from "@/models/file-system/EntryCreation";

export interface NodeClient {
  getNode(id: string): Promise<NodeResult>;

  createNode(entryCreation: EntryCreation): Promise<NodeResult>;

  updateNode(id: string, newName: string): Promise<NodeResult>;

  deleteNode(id: string): Promise<void>;
}