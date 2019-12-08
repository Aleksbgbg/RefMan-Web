<template lang="pug">
div
  c-file-system-entry(
    image="/img/folder.svg"
    imageExpanded="/img/open-folder.svg"
    :canExpand="canExpand"
    :isExpanded="isExpanded"
    :node="folder"
    @expand="expand"
    @finishedEditing="finishedEditing"
  )
  .ml-5(v-if="canExpand" v-show="isExpanded")
    c-node-list(:model="folder")
</template>

<script>
import FileSystemEntryComponent from "./FileSystemEntry";
import { File } from "@/models/file-tree/File";
import { Folder } from "@/models/file-tree/Folder";
import { fileSystemClient } from "@/services/api-clients/FileSystemClient";

export default {
  components: {
    "c-file-system-entry": FileSystemEntryComponent,
    "c-node-list": () => import("./NodeList")
  },
  props: {
    model: Folder
  },
  data() {
    return {
      isExpanded: false,
      folder: this.model
    };
  },
  computed: {
    canExpand() {
      return this.model.canExpand;
    }
  },
  methods: {
    async expand() {
      if (this.canExpand) {
        if (!this.isExpanded && !this.hasBeenExpanded) {
          this.hasBeenExpanded = true;

          const expansion = await fileSystemClient.getFolderExpansion(this.folder.id);

          this.folder.folders = expansion.folders.map(Folder.fromFolderResult);
          this.folder.files = expansion.files.map(File.fromNodeResult);
        }

        this.isExpanded = !this.isExpanded;
      }
    },
    async finishedEditing() {
      if (!this.model.existsInPersistentStore) {
        const nodeResult = await fileSystemClient.createFolder({
          parentIdString: this.model.parentId,
          name: this.model.name
        });

        this.model.id = nodeResult.idString;
        this.model.name = nodeResult.name;

        this.model.parent.sortFolders();
      }
    }
  }
};
</script>