import { ReferenceResult } from "@/models/referencing/ReferenceResult";

export interface DocumentResult {
  id: number;

  idString: string;

  references: ReferenceResult[];
}