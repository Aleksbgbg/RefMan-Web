import { Focusable } from "./Focusable";
import { Node } from "@/models/Node";

export interface FocusManager {
    focus(focusable: Focusable, node: Node): void;

    removeFocus(): void;
}