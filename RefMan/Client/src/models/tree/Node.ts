import { Optional } from "@/types/Optional";

export interface Node {
  id: string;

  name: string;

  parent: Optional<Node>;

  parentId: Optional<string>;

  isBranch: boolean;

  isLeaf: boolean;
}