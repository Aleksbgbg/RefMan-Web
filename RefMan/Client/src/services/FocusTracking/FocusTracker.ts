import { Focal } from "./Focal";

export interface FocusTracker {
    getFocal(): Focal | null;
}