import { FocusManager } from "./FocusManager";
import { FocusTracker } from "./FocusTracker";
import { Focusable } from "./Focusable";

export class FocusManagerImpl implements FocusManager, FocusTracker {
    private _currentFocus: Focusable | null = null;

    public getFocusedNode(): Focusable | null {
      return this._currentFocus;
    }

    public focus(focusable: Focusable): void {
      if (this._currentFocus) {
        this._currentFocus.removeFocus();
      }

      this._currentFocus = focusable;
      this._currentFocus.focus();
    }
}