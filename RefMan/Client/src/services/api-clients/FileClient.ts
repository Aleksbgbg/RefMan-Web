import { ApiClientBase } from "./ApiClientBase";
import { EntryCreation } from "@/models/file-system/EntryCreation";
import { NodeResult } from "@/models/file-system/NodeResult";

class FileClient extends ApiClientBase {
  constructor() {
    super("file");
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