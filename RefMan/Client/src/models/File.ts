import { Node } from "./Node";

export class File extends Node {
  public get isLeaf(): boolean {
    return true;
  }
}