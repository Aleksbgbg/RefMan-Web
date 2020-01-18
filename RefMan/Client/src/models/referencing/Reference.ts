import { Optional } from "@/types/Optional";

export interface Reference {
  id: string;

  accessDate: Date;

  publishYear: Optional<Number>;

  websiteName: string;

  webpageTitle: string;

  url: string;

  iconUrl: string;
}