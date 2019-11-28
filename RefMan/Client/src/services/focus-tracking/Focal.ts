import { Focusable } from "./Focusable";
import { Editable } from "./Editable";
import { Node } from "@/models/file-tree/Node";

export interface Focal {
    focusable: Focusable;

    editable: Editable;

    node: Node;
}