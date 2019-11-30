import { ApiClientBase } from "./ApiClientBase";
import { Folder } from "@/models/file-tree/Folder";

class FileSystemClient extends ApiClientBase {
  public root(): Promise<Folder> {
    return this.get("file-system/root");
  }
}

export const fileSystemClient = new FileSystemClient();