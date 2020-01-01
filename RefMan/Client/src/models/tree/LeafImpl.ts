import { NodeImpl } from "@/models/tree/NodeImpl";
import { Leaf } from "@/models/tree/Leaf";

export class LeafImpl extends NodeImpl implements Leaf {
  public get isBranch(): boolean {
    return false;
  }
}