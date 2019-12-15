import { createNodePersist } from "@/mixins/node-persistence/NodePersist";
import { fileClient } from "@/services/api-clients/FileClient";

export default createNodePersist(
  fileClient.createFile.bind(fileClient),
  fileClient.updateFile.bind(fileClient),
  (parent) => parent.sortFiles.bind(parent)
);