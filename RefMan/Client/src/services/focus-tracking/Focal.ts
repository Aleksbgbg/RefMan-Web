import { Focusable } from "@/services/focus-tracking/Focusable";
import { Node } from "@/models/tree/Node";

export interface Focal {
  focusable: Focusable;

  node: Node;
}