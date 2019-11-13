import { FocusManager } from "./FocusManager";
import { FocusTracker } from "./FocusTracker";
import { Focal } from "./Focal";

export class FocusManagerImpl implements FocusManager, FocusTracker {
    private _currentFocal: Focal | null = null;

    public getFocal(): Focal | null {
      return this._currentFocal;
    }

    public focus(focal: Focal): void {
      if (this._currentFocal) {
        this._currentFocal.focusable.removeFocus();
      }

      this._currentFocal = focal;
      this._currentFocal.focusable.focus();
    }

    public removeFocus(): void {
      if (this._currentFocal) {
        this._currentFocal.focusable.removeFocus();
      }

      this._currentFocal = null;
    }
}