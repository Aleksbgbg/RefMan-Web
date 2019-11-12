import { Folder } from "./Folder";

export class Node {
    private readonly _name: string;

    private _parent: Folder | null = null;

    constructor(name: string) {
      this._name = name;
    }

    public get name(): string {
      return this._name;
    }

    public get parent(): Folder | null {
      return this._parent;
    }

    public set parent(value: Folder | null) {
      this._parent = value;
    }
}