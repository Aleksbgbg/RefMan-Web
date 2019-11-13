import { Focusable } from "./Focusable";
import { Editable } from "./Editable";
import { Node } from "@/models/Node";

export interface FocusTracker {
    getCurrentFocusable(): Focusable | null;

    getCurrentEditable(): Editable | null;

    getFocusedNode(): Node | null;
}