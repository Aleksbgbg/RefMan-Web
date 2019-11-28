import { FocusManager } from "./FocusManager";
import { FocusManagerImpl } from "./FocusManagerImpl";
import { FocusTracker } from "./FocusTracker";

interface FocusTrackingPair {
  focusManager: FocusManager;

  focusTracker: FocusTracker;
}

export function createFocusTrackers(): FocusTrackingPair {
  const implementation = new FocusManagerImpl();

  return {
    focusManager: implementation,
    focusTracker: implementation
  };
}