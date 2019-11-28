import { Focal } from "./Focal";

export interface FocusManager {
    focus(focal: Focal): void;

    removeFocus(): void;
}