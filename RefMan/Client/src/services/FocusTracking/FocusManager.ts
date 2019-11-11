import { Focusable } from "./Focusable";

export interface FocusManager {
    focus(focusable: Focusable): void;
}