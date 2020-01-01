import { Focal } from "@/services/focus-tracking/Focal";

export interface FocusManager {
  focus(focal: Focal): void;

  removeFocus(): void;
}