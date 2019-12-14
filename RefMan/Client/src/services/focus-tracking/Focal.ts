import { Focusable } from "./Focusable";
import { Deletable } from "@/services/focus-tracking/Deletable";
import { Node } from "@/models/file-tree/Node";

export interface Focal {
    focusable: Focusable;

    deletable: Deletable;

    node: Node;
}