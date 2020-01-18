import { File } from "@/models/file-tree/File";
import { Document } from "@/models/referencing/Document";

interface FileDocumentCoupling {
  file: File;

  document: Document;
}

export class FileDocumentGraph {
  private readonly _fileMap = new Map();

  private readonly _documentMap = new Map();

  public containsFile(file: File): boolean {
    return this.hasFile(file);
  }

  public getDocument(file: File): Document {
    return this.getByFile(file).document;
  }

  public add(fileDocumentCoupling: FileDocumentCoupling): void {
    const file = fileDocumentCoupling.file;
    const document = fileDocumentCoupling.document;

    this._fileMap.set(file.id, fileDocumentCoupling);
    this._documentMap.set(document.id, fileDocumentCoupling);
  }

  public removeDocument(document: Document): void {
    this.removeCoupling(this._documentMap.get(document.id));
  }

  private hasFile(file: File) {
    return this._fileMap.has(file.id);
  }

  private getByFile(file: File): FileDocumentCoupling {
    return this._fileMap.get(file.id);
  }

  private removeCoupling(fileDocumentCoupling: FileDocumentCoupling): void {
    const file = fileDocumentCoupling.file;
    const document = fileDocumentCoupling.document;

    this.deleteFile(file);
    this.deleteDocument(document);
  }

  private deleteFile(file: File) {
    this._fileMap.delete(file.id);
  }

  private deleteDocument(document: Document) {
    this._documentMap.delete(document.id);
  }
}