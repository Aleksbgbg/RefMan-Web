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

      this.emitFocusChanged();
    }

    public removeFocus(): void {
      if (this._currentFocal) {
        this._currentFocal.focusable.removeFocus();
      }

      this._currentFocal = null;

      this.emitFocusChanged();
    }

    private emitFocusChanged(): void {
      this._focusRoot.onFocusChanged(this._currentFocal);
    }
}