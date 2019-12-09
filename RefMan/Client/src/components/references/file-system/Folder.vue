<template lang="pug">
div
  c-file-system-entry(
    image="/img/folder.svg"
    imageExpanded="/img/open-folder.svg"
    :canExpand="canExpand"
    :isExpanded="isExpanded"
    :node="model"
    @toggleExpansion="toggleExpansion"
    @finishedEditing="finishedEditing"
  )
  .ml-5(v-if="canExpand" v-show="isExpanded")
    c-node-list(:model="model")
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
  computed: {
    canExpand() {
      return this.model.canExpand;
    },
    isExpanded() {
      return this.model.isExpanded;
    }
  },
  watch: {
    async isExpanded() {
      await this.ensureChildrenPopulated();
    }
  },
  methods: {
    async toggleExpansion() {
      await this.ensureChildrenPopulated();
      this.model.toggleExpansion();
    },
    async ensureChildrenPopulated() {
      if (!this.childrenPopulated) {
        await this.populateChildren();
        this.childrenPopulated = true;
      }
    },
    async populateChildren() {
      const expansion = await fileSystemClient.getFolderExpansion(this.model.id);

      this.model.addFolders(expansion.folders.map(Folder.fromFolderResult));
      this.model.addFiles(expansion.files.map(File.fromNodeResult));
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