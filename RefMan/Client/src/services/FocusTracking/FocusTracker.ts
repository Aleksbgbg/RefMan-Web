import { Focusable } from "./Focusable";
import { Node } from "@/models/Node";

export interface FocusTracker {
    getCurrentFocusable(): Focusable | null;

    getFocusedNode(): Node | null;
}