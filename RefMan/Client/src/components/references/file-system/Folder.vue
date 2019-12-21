<template lang="pug">
li
  c-file-system-entry(
    image="/img/folder.svg"
    imageExpanded="/img/open-folder.svg"
    :canExpand="canExpand"
    :isExpanded="isExpanded"
    :node="model"
    @toggleExpansion="toggleExpansion"
    @submitEdit="submitEdit"
    @cancelEdit="cancelEdit"
  )
  c-node-list.ml-5(v-if="canExpand" v-show="isExpanded" :model="model")
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
  provide() {
    return {
      parent: this
    };
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
  methods: {
    async toggleExpansion() {
      await this.ensureChildrenPopulated();
      this.model.toggleExpansion();
    },
    async ensureChildrenPopulated() {
      if (this.canExpand && !this.childrenPopulated) {
        await this.populateChildren();
        this.childrenPopulated = true;
      }
    },
    async populateChildren() {
      const expansion = await folderClient.getFolderExpansion(this.model.id);

      this.model.addFolders(expansion.folders.map(Folder.fromFolderResult));
      this.model.addFiles(expansion.files.map(File.fromNodeResult));
    },
    async submitEdit(newName) {
      await this.submitNodeEdit(this.model, newName);
    },
    cancelEdit() {
      this.cancelNodeEdit(this.model);
    },
    async delete() {
      await this.deleteNode(this.model);
    }
  }
};
</script>