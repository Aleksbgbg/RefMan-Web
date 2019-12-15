import { createNodePersist } from "@/mixins/node-persistence/NodePersist";
import { folderClient } from "@/services/api-clients/FolderClient";

export default createNodePersist(
  folderClient.createFolder.bind(folderClient),
  folderClient.updateFolder.bind(folderClient),
  (parent) => parent.sortFolders.bind(parent)
);