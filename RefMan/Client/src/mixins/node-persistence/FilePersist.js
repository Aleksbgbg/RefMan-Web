import { createNodePersist } from "@/mixins/node-persistence/NodePersist";
import { fileSystemClient } from "@/services/api-clients/FileSystemClient";

export default createNodePersist(
  fileSystemClient.createFile.bind(fileSystemClient),
  (parent) => parent.sortFiles.bind(parent)
);