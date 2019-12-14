import { createNodePersist } from "@/mixins/node-persistence/NodePersist";
import { fileSystemClient } from "@/services/api-clients/FileSystemClient";

export default createNodePersist(
  fileSystemClient.createFolder.bind(fileSystemClient),
  (parent) => parent.sortFolders.bind(parent)
);