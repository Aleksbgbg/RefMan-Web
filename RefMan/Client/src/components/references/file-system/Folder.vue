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
import FolderPersistMixin from "@/mixins/node-persistence/FolderPersist";
import FileSystemEntryComponent from "./FileSystemEntry";
import { File } from "@/models/file-tree/File";
import { Folder } from "@/models/file-tree/Folder";
import { folderClient } from "@/services/api-clients/FolderClient";

export default {
  mixins: [FolderPersistMixin],
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
      const expansion = await folderClient.getFolderExpansion(this.model.id);

      this.model.addFolders(expansion.folders.map(Folder.fromFolderResult));
      this.model.addFiles(expansion.files.map(File.fromNodeResult));
    }
  }
};
</script>