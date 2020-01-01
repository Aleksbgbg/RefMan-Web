import { ApiClientBase } from "./ApiClientBase";
import { NodeClient } from "@/services/api-clients/NodeClient";
import { RootFolderResult } from "@/models/file-system/RootFolderResult";
import { EntryCreation } from "@/models/file-system/EntryCreation";
import { NodeResult } from "@/models/file-system/NodeResult";
import { Folder } from "@/models/file-tree/Folder";
import { fileSystemFactory } from "@/services/api-clients/FileSystemFactory";
import { ExpandFolder } from "@/models/file-system/ExpandFolder";

class FolderClient extends ApiClientBase implements NodeClient {
  constructor() {
    super("folder");
  }

  public async getRoot(): Promise<Folder> {
    return fileSystemFactory.folderFromRootFolderResult(await this.get<RootFolderResult>("root"));
  }

  public async getFolderExpansion(id: string): Promise<ExpandFolder> {
    return fileSystemFactory.expandFolderFromExpandFolderResult(await this.get(`expansion/${id}`));
  }

  public getFolder(id: string): Promise<NodeResult> {
    return this.get(id);
  }

  public createFolder(entryCreation: EntryCreation): Promise<NodeResult> {
    return this.post("", entryCreation);
  }

  public updateFolder(id: string, newName: string): Promise<NodeResult> {
    return this.put(id, {
      name: newName
    });
  }

  public deleteFolder(id: string): Promise<void> {
    return this.delete(id);
  }

  public getNode(id: string): Promise<NodeResult> {
    return this.getFolder(id);
  }

  public createNode(entryCreation: EntryCreation): Promise<NodeResult> {
    return this.createFolder(entryCreation);
  }

  public updateNode(id: string, newName: string): Promise<NodeResult> {
    return this.updateFolder(id, newName);
  }

  public deleteNode(id: string): Promise<void> {
    return this.deleteFolder(id);
  }
}

export const folderClient = new FolderClient();