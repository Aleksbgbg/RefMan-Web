import { ApiClientBase } from "./ApiClientBase";
import { NodeClient } from "@/services/api-clients/NodeClient";
import { EntryCreation } from "@/models/file-system/EntryCreation";
import { NodeResult } from "@/models/file-system/NodeResult";

class FileClient extends ApiClientBase implements NodeClient {
  constructor() {
    super("file");
  }

  public getNode(id: string): Promise<NodeResult> {
    return this.getFile(id);
  }

  public createNode(entryCreation: EntryCreation): Promise<NodeResult> {
    return this.createFile(entryCreation);
  }

  public updateNode(id: string, newName: string): Promise<NodeResult> {
    return this.updateFile(id, newName);
  }

  public deleteNode(id: string): Promise<void> {
    return this.deleteFile(id);
  }

  public getFile(id: string): Promise<NodeResult> {
    return this.get(id);
  }

  public createFile(entryCreation: EntryCreation): Promise<NodeResult> {
    return this.post("", entryCreation);
  }

  public updateFile(id: string, newName: string): Promise<NodeResult> {
    return this.put(id, {
      name: newName
    });
  }

  public deleteFile(id: string): Promise<void> {
    return this.delete(id);
  }
}

export const fileClient = new FileClient();