import { ApiClientBase } from "./ApiClientBase";
import { RootFolderResult } from "@/models/file-system/RootFolderResult";

class FileSystemClient extends ApiClientBase {
  public root(): Promise<RootFolderResult> {
    return this.get("file-system/root");
  }
}

export const fileSystemClient = new FileSystemClient();