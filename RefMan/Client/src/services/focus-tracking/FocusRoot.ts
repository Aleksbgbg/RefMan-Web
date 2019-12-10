import { Focal } from "@/services/focus-tracking/Focal";

export interface FocusRoot {
  onFocusChanged(focal: Focal): void;
}