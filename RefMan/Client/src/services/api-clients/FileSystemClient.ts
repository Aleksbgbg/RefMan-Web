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

  public getFolder(id: string): Promise<NodeResult> {
    return this.get(`folder/${id}`);
  }

  public getFile(id: string): Promise<NodeResult> {
    return this.get(`file/${id}`);
  }

  public getFolderExpansion(id: string): Promise<ExpandFolderResult> {
    return this.get(`folder-expansion/${id}`);
  }

  public createFolder(entryCreation: EntryCreation): Promise<NodeResult> {
    return this.post("folder", entryCreation);
  }

  public createFile(entryCreation: EntryCreation): Promise<NodeResult> {
    return this.post("file", entryCreation);
  }
}

export const fileSystemClient = new FileSystemClient();