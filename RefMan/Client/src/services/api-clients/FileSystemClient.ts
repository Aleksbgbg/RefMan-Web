import { ApiClientBase } from "./ApiClientBase";
import { RootFolderResult } from "@/models/file-system/RootFolderResult";
import { ExpandFolderResult } from "@/models/file-system/ExpandFolderResult";
import { EntryCreation } from "@/models/file-system/EntryCreation";
import { NodeResult } from "@/models/file-system/NodeResult";

class FileSystemClient extends ApiClientBase {
  constructor() {
    super("file-system");
  }

  public root(): Promise<RootFolderResult> {
    return this.get("root");
  }

  public getFolderExpansion(id: string): Promise<ExpandFolderResult> {
    return this.get(`folder-expansion/${id}`);
  }

  public createFolder(entryCreation: EntryCreation): Promise<NodeResult> {
    return this.post("folder", entryCreation);
  }
}

export const fileSystemClient = new FileSystemClient();