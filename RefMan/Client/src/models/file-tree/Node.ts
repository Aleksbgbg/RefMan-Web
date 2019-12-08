export abstract class Node {
    private _id: string;

    private _name: string;

    private _parent: Node | null = null;

    private _isEditing: boolean = false;

    constructor(id: string, name: string = "") {
      this._id = id;
      this._name = name;
    }

    public abstract get isLeaf(): boolean;

    public get existsInPersistentStore(): boolean {
      return this.id !== "0";
    }

    public get id(): string {
      return this._id;
    }

    public set id(value: string) {
      this._id = value;
    }

    public get parentId(): string | null {
      if (this._parent) {
        return this._parent.id;
      }

      return null;
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