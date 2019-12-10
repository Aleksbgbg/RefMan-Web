import { FocusManager } from "./FocusManager";
import { FocusManagerImpl } from "./FocusManagerImpl";
import { FocusRoot } from "@/services/focus-tracking/FocusRoot";

export function createFocusManager(focusRoot: FocusRoot): FocusManager {
  return new FocusManagerImpl(focusRoot);
}