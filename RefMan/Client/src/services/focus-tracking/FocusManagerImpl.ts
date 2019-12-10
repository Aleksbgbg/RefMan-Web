import { FocusManager } from "./FocusManager";
import { Focal } from "./Focal";
import { FocusRoot } from "@/services/focus-tracking/FocusRoot";

export class FocusManagerImpl implements FocusManager {
    private readonly _focusRoot: FocusRoot;

    private _currentFocal: Focal | null = null;

    constructor(focusRoot: FocusRoot) {
      this._focusRoot = focusRoot;
    }

    public focus(focal: Focal): void {
      if (this._currentFocal) {
        this._currentFocal.focusable.removeFocus();
      }

      this._currentFocal = focal;
      this._currentFocal.focusable.focus();

      this._focusRoot.onFocusChanged(focal);
    }

    public removeFocus(): void {
      if (this._currentFocal) {
        this._currentFocal.focusable.removeFocus();
      }

      this._currentFocal = null;
    }
}