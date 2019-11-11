import { FocusManager } from "./FocusManager";
import { Focusable } from "./Focusable";

export class FocusManagerImpl implements FocusManager {
    private _currentFocus: Focusable | null = null;

    public focus(focusable: Focusable): void {
      if (this._currentFocus) {
        this._currentFocus.removeFocus();
      }

      this._currentFocus = focusable;
      this._currentFocus.focus();
    }
}