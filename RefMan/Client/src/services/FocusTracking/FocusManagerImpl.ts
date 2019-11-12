import { FocusManager } from "./FocusManager";
import { FocusTracker } from "./FocusTracker";
import { Focusable } from "./Focusable";
import { Node } from "@/models/Node";

export class FocusManagerImpl implements FocusManager, FocusTracker {
    private _currentFocus: Focusable | null = null;

    private _currentNode: Node | null = null;

    public getCurrentFocusable(): Focusable | null {
      return this._currentFocus;
    }

    public getFocusedNode(): Node | null {
      return this._currentNode;
    }

    public focus(focusable: Focusable, node: Node): void {
      if (this._currentFocus) {
        this._currentFocus.removeFocus();
      }

      this._currentNode = node;
      this._currentFocus = focusable;
      this._currentFocus.focus();
    }

    public removeFocus(): void {
      if (this._currentFocus) {
        this._currentFocus.removeFocus();
      }
      this._currentFocus = null;
      this._currentNode = null;
    }
}