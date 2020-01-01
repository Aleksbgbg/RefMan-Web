import { Node } from "@/models/tree/Node";

export interface FileSystemEntry extends Node {
  existsInPersistentStore: boolean;

  isEditing: boolean;

  beginEditing(): void;

  stopEditing(): void;
}