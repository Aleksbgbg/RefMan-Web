import { Leaf } from "@/models/tree/Leaf";
import { FileSystemEntry } from "@/models/file-tree/FileSystemEntry";

export interface File extends FileSystemEntry, Leaf { }