import { ApiClientBase } from "@/services/api-clients/ApiClientBase";
import { ReferenceResult } from "@/models/referencing/ReferenceResult";
import { ReferenceEdit } from "@/models/referencing/ReferenceEdit";

class DocumentClient extends ApiClientBase {
  constructor() {
    super("document");
  }

  public getReferences(documentId: string): Promise<ReferenceResult[]> {
    return this.get(`${documentId}/references`);
  }

  public getReference(documentId: string, referenceId: string): Promise<ReferenceResult> {
    return this.get(`${documentId}/reference/${referenceId}`);
  }

  public createReference(documentId: string, url: string): Promise<ReferenceResult> {
    return this.post(`${documentId}/reference`, {
      url
    });
  }

  public editReference(documentId: string, referenceId: string, referenceEdit: ReferenceEdit): Promise<ReferenceResult> {
    return this.put(`${documentId}/reference/${referenceId}`, referenceEdit);
  }

  public async deleteReference(documentId: string, referenceId: string): Promise<void> {
    await this.delete(`${documentId}/reference/${referenceId}`);
  }
}

export const documentClient = new DocumentClient();