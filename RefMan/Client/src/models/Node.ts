export class Node {
    private readonly _name: string;

    private _parent: Node | null = null;

    constructor(name: string) {
      this._name = name;
    }

    public get name(): string {
      return this._name;
    }

    public get parent(): Node | null {
      return this._parent;
    }

    public set parent(value: Node | null) {
      this._parent = value;
    }
}