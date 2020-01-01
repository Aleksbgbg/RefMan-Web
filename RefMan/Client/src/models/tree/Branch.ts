import { Node } from "@/models/tree/Node";
import { Leaf } from "@/models/tree/Leaf";
import { ReadonlyCollection } from "@/models/tree/ReadonlyCollection";

export interface Branch extends Node {
  canExpand: boolean;

  isExpanded: boolean;

  branches: ReadonlyCollection<Branch>;

  leaves: ReadonlyCollection<Leaf>;

  add(node: Node): void;

  addBranch(branch: Branch): void;

  addLeaf(leaf: Leaf): void;

  remove(node: Node): void;

  removeBranch(branch: Branch): void;

  removeLeaf(leaf: Leaf): void;

  expand(): void;

  collapse(): void;
}