import { FocusManager } from "./FocusManager";
import { FocusTracker } from "./FocusTracker";
import { Focusable } from "./Focusable";
import { Editable } from "./Editable";
import { Node } from "@/models/Node";

export class FocusManagerImpl implements FocusManager, FocusTracker {
    private _currentFocus: Focusable | null = null;

    private _currentEditable: Editable | null = null;

    private _currentNode: Node | null = null;

    public getCurrentFocusable(): Focusable | null {
      return this._currentFocus;
    }

    public getCurrentEditable(): Editable | null {
      return this._currentEditable;
    }

    public getFocusedNode(): Node | null {
      return this._currentNode;
    }

    public focus(focusable: Focusable, editable: Editable, node: Node): void {
      if (this._currentFocus) {
        this._currentFocus.removeFocus();
      }

      this._currentFocus = focusable;
      this._currentEditable = editable;
      this._currentNode = node;

      this._currentFocus.focus();
    }

    public removeFocus(): void {
      if (this._currentFocus) {
        this._currentFocus.removeFocus();
      }
      this._currentFocus = null;
      this._currentEditable = null;
      this._currentNode = null;
    }
}