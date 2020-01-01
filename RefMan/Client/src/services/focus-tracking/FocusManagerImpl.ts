import { FocusManager } from "@/services/focus-tracking/FocusManager";
import { FocusRoot } from "@/services/focus-tracking/FocusRoot";
import { Optional } from "@/types/Optional";
import { Focal } from "@/services/focus-tracking/Focal";

export class FocusManagerImpl implements FocusManager {
  private readonly _focusRoot: FocusRoot;

  private _currentFocal: Optional<Focal> = null;

  constructor(focusRoot: FocusRoot) {
    this._focusRoot = focusRoot;
  }

  public focus(focal: Focal): void {
    this.removeFocusFromCurrentFocal();

    this._currentFocal = focal;
    this._currentFocal.focusable.focus();

    this.emitFocusChanged();
  }

  public removeFocus(): void {
    this.removeFocusFromCurrentFocal();

    this._currentFocal = null;

    this.emitFocusChanged();
  }

  private removeFocusFromCurrentFocal(): void {
    if (this._currentFocal) {
      this._currentFocal.focusable.removeFocus();
    }
  }

  private emitFocusChanged(): void {
    this._focusRoot.onFocusChanged(this._currentFocal);
  }
}