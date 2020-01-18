import { ReferenceResult } from "@/models/referencing/ReferenceResult";
import { Reference } from "@/models/referencing/Reference";
import { File } from "@/models/file-tree/File";
import { Document } from "@/models/referencing/Document";
import { fileClient } from "@/services/api-clients/FileClient";

function referenceResultToReference(referenceResult: ReferenceResult): Reference {
  return {
    id: referenceResult.idString,
    accessDate: new Date(referenceResult.accessDate),
    publishYear: referenceResult.publishYear,
    websiteName: referenceResult.websiteName,
    webpageTitle: referenceResult.webpageTitle,
    url: referenceResult.url,
    iconUrl: referenceResult.iconUrl
  };
}

class FileDocumentExpander {
  public async getDocumentFor(file: File): Promise<Document> {
    const documentResult = await fileClient.getFileDocument(file.id);

    return {
      id: documentResult.idString,
      name: file.name,
      references: documentResult.references.map(referenceResultToReference)
    };
  }
}

export const fileDocumentExpander = new FileDocumentExpander();