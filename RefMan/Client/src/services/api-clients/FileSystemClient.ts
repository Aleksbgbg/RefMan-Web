import { ApiClientBase } from "./ApiClientBase";
import { RootFolderResult } from "@/models/file-system/RootFolderResult";
import { FolderResult } from "@/models/file-system/FolderResult";

class FileSystemClient extends ApiClientBase {
  public root(): Promise<RootFolderResult> {
    return this.get("file-system/root");
  }

  public getFolder(id: string): Promise<FolderResult> {
    return this.get(`file-system/folder/${id}`);
  }
}

export const fileSystemClient = new FileSystemClient();