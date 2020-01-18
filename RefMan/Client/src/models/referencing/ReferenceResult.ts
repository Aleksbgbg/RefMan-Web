import { Optional } from "@/types/Optional";

export interface ReferenceResult {
  id: number;

  idString: string;

  accessDate: string;

  publishYear: Optional<Number>;

  websiteName: string;

  webpageTitle: string;

  url: string;

  iconUrl: string;
}