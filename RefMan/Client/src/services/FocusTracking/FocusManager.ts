import { Focusable } from "./Focusable";
import { Editable } from "./Editable";
import { Node } from "@/models/Node";

export interface FocusManager {
    focus(focusable: Focusable, editable: Editable, node: Node): void;

    removeFocus(): void;
}