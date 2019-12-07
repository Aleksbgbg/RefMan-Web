import { ApiClientBase } from "./ApiClientBase";
import { RootFolderResult } from "@/models/file-system/RootFolderResult";
import { ExpandFolderResult } from "@/models/file-system/ExpandFolderResult";

class FileSystemClient extends ApiClientBase {
  public root(): Promise<RootFolderResult> {
    return this.get("file-system/root");
  }

  public getFolderExpansion(id: string): Promise<ExpandFolderResult> {
    return this.get(`file-system/folder-expansion/${id}`);
  }
}

export const fileSystemClient = new FileSystemClient();