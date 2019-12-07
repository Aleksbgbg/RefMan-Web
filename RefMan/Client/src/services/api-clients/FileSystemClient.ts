import { ApiClientBase } from "./ApiClientBase";
import { RootFolderResult } from "@/models/file-system/RootFolderResult";
import { ExpandFolderResult } from "@/models/file-system/ExpandFolderResult";

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
}

export const fileSystemClient = new FileSystemClient();