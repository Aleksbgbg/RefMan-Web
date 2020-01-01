import { Node } from "@/models/tree/Node";
import { ReadonlyCollection } from "@/models/tree/ReadonlyCollection";
import { NodeImpl } from "@/models/tree/NodeImpl";
import { Branch } from "@/models/tree/Branch";
import { OrderedCollection } from "@/models/tree/OrderedCollection";
import { Leaf } from "@/models/tree/Leaf";

const sortFunc = (a: Node, b: Node) => a.name.localeCompare(b.name);

export class BranchImpl extends NodeImpl implements Branch {
  private readonly _branches: OrderedCollection<Branch> = new OrderedCollection<Branch>(sortFunc);

  private readonly _leaves: OrderedCollection<Leaf> = new OrderedCollection<Leaf>(sortFunc);

  private _isExpanded: boolean = false;

  public get isBranch(): boolean {
    return true;
  }

  public get canExpand(): boolean {
    return this._branches.length > 0 ||
           this._leaves.length > 0;
  }

  public get isExpanded(): boolean {
    return this._isExpanded;
  }

  public expand(): void {
    this._isExpanded = true;
  }

  public collapse(): void {
    this._isExpanded = false;
  }

  public get branches(): ReadonlyCollection<Branch> {
    return this._branches;
  }

  public get leaves(): ReadonlyCollection<Leaf> {
    return this._leaves;
  }

  public add(node: Node): void {
    if (node.isBranch) {
      this.addBranch(node as Branch);
    } else {
      this.addLeaf(node as Leaf);
    }
  }

  public addBranch(branch: Branch): void {
    this.addNodeToCollection(this._branches, branch);
  }

  public addLeaf(leaf: Leaf): void {
    this.addNodeToCollection(this._leaves, leaf);
  }

  public remove(node: Node): void {
    if (node.isBranch) {
      this.removeBranch(node as Branch);
    } else {
      this.removeLeaf(node as Leaf);
    }
  }

  public removeBranch(branch: Branch): void {
    this.removeNodeFromCollection(this._branches, branch);
  }

  public removeLeaf(leaf: Leaf): void {
    this.removeNodeFromCollection(this._leaves, leaf);
  }

  private addNodeToCollection<T extends Node>(nodes: OrderedCollection<T>, node: T) {
    node.parent = this;
    nodes.add(node);
  }

  private removeNodeFromCollection<T extends Node>(nodes: OrderedCollection<T>, node: T) {
    node.parent = null;
    nodes.remove(node);
  }
}