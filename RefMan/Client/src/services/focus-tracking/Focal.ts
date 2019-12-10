import { Focusable } from "./Focusable";
import { Node } from "@/models/file-tree/Node";

export interface Focal {
    focusable: Focusable;

    node: Node;
}