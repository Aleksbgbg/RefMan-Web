import { ApiClientBase } from "./ApiClientBase";
import { RootFolderResult } from "@/models/file-system/RootFolderResult";
import { ExpandFolderResult } from "@/models/file-system/ExpandFolderResult";
import { EntryCreation } from "@/models/file-system/EntryCreation";
import { NodeResult } from "@/models/file-system/NodeResult";

class FolderClient extends ApiClientBase {
  constructor() {
    super("folder");
  }

  public getRoot(): Promise<RootFolderResult> {
    return this.get("root");
  }

  public getFolderExpansion(id: string): Promise<ExpandFolderResult> {
    return this.get(`expansion/${id}`);
  }

  public getFolder(id: string): Promise<NodeResult> {
    return this.get(id);
  }

  public createFolder(entryCreation: EntryCreation): Promise<NodeResult> {
    return this.post("", entryCreation);
  }
}

export const folderClient = new FolderClient();