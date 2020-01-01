import { createNodePersist } from "@/mixins/node-persistence/NodePersist";
import { folderClient } from "@/services/api-clients/FolderClient";
import { folderFactory } from "@/services/FolderFactory";

export default createNodePersist(folderClient, folderFactory);