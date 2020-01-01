import { FocusManagerImpl } from "@/services/focus-tracking/FocusManagerImpl";
import { FocusManager } from "@/services/focus-tracking/FocusManager";
import { FocusRoot } from "@/services/focus-tracking/FocusRoot";

export function createFocusManager(focusRoot: FocusRoot): FocusManager {
  return new FocusManagerImpl(focusRoot);
}