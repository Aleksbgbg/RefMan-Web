import { Node } from "@/models/tree/Node";
import { Optional } from "@/types/Optional";

export abstract class NodeImpl implements Node {
  private readonly _id: string;

  private _name: string;

  private _parent: Optional<Node> = null;

  constructor(id: string, name: string) {
    this._id = id;
    this._name = name;
  }

  public get id(): string {
    return this._id;
  }

  public get name(): string {
    return this._name;
  }

  public set name(value: string) {
    this._name = value;
  }

  public get parent(): Optional<Node> {
    return this._parent;
  }

  public set parent(value: Optional<Node>) {
    this._parent = value;
  }

  public get parentId(): Optional<string> {
    return this._parent === null ? null : this._parent.id;
  }

  public abstract get isBranch(): boolean;

  public get isLeaf(): boolean {
    return !this.isBranch;
  }
}