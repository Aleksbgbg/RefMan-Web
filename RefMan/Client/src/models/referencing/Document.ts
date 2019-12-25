import { Reference } from "@/models/referencing/Reference";

export interface Document {
  id: string;

  name: string;

  references: Reference[];
}