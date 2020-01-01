import { createNodePersist } from "@/mixins/node-persistence/NodePersist";
import { fileClient } from "@/services/api-clients/FileClient";
import { fileFactory } from "@/services/FileFactory";

export default createNodePersist(fileClient, fileFactory);