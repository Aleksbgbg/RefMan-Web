import { FocusManager } from "./FocusManager";
import { FocusManagerImpl } from "./FocusManagerImpl";
import { FocusTracker } from "./FocusTracker";
import { FocusRoot } from "@/services/focus-tracking/FocusRoot";

interface FocusTrackingPair {
  focusManager: FocusManager;

  focusTracker: FocusTracker;
}

export function createFocusTrackers(focusRoot: FocusRoot): FocusTrackingPair {
  const implementation = new FocusManagerImpl(focusRoot);

  return {
    focusManager: implementation,
    focusTracker: implementation
  };
}