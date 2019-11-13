import { Focusable } from "./Focusable";
import { Editable } from "./Editable";
import { Node } from "@/models/Node";

export interface Focal {
    focusable: Focusable;

    editable: Editable;

    node: Node;
}