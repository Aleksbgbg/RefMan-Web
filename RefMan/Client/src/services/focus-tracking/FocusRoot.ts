import { Optional } from "@/types/Optional";
import { Focal } from "@/services/focus-tracking/Focal";

export interface FocusRoot {
  onFocusChanged(focal: Optional<Focal>): void;
}