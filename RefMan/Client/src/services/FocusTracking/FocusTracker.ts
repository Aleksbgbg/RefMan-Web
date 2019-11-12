import { Focusable } from "./Focusable";

export interface FocusTracker {
    getFocusedNode(): Focusable | null;
}