import { Node } from "./Node";
import { NodeResult } from "@/models/file-system/NodeResult";

export class File extends Node {
  public static fromNodeResult(nodeResult: NodeResult): File {
    return new File(nodeResult.id, nodeResult.name);
  }

  public get isLeaf(): boolean {
    return true;
  }
}