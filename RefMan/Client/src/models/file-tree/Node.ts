export abstract class Node {
    private readonly _id: number;

    private _name: string;

    private _parent: Node | null = null;

    private _isEditing: boolean = false;

    constructor(id: number, name: string = "") {
      this._id = id;
      this._name = name;
    }

    public abstract get isLeaf(): boolean;

    public get id(): number {
      return this._id;
    }

    public get name(): string {
      return this._name;
    }

    public set name(value: string) {
      this._name = value;
    }

    public get parent(): Node | null {
      return this._parent;
    }

    public set parent(value: Node | null) {
      this._parent = value;
    }

    public get isEditing(): boolean {
      return this._isEditing;
    }

    public set isEditing(value: boolean) {
      this._isEditing = value;
    }
}