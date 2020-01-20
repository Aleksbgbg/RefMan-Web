import { Document } from "@/models/referencing/Document";
import { documentClient } from "@/services/api-clients/DocumentClient";

class Referencer {
  public async addReference(document: Document, url: string): Promise<void> {
    const referenceResult = await documentClient.createReference(document.id, url);
    document.references.push({
      id: referenceResult.idString,
      accessDate: new Date(referenceResult.accessDate),
      publishYear: referenceResult.publishYear,
      websiteName: referenceResult.websiteName,
      webpageTitle: referenceResult.webpageTitle,
      url: referenceResult.url,
      iconUrl: referenceResult.iconUrl
    });
  }
}

export const referencer = new Referencer();