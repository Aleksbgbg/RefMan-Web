import { FocusManager } from "./FocusManager";
import { FocusManagerImpl } from "./FocusManagerImpl";
import { FocusTracker } from "./FocusTracker";

const implementation = new FocusManagerImpl();

export const focusManager: FocusManager = implementation;
export const focusTracker: FocusTracker = implementation;