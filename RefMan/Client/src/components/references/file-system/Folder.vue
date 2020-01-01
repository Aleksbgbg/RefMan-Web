<template lang="pug">
c-file-system-entry(
  :image="isExpanded ? '/img/open-folder.svg' : '/img/folder.svg'"
  :fileSystemEntry="folder"
  @submitEdit="submitEdit"
  @cancelEdit="cancelEdit"
)
</template>

<script>
import FolderPersistMixin from "@/mixins/node-persistence/FolderPersist";
import FileSystemEntryComponent from "./FileSystemEntry";
import { Folder } from "@/models/file-tree/Folder";
import { folderClient } from "@/services/api-clients/FolderClient";

export default {
  mixins: [FolderPersistMixin],
  components: {
    "c-file-system-entry": FileSystemEntryComponent
  },
  props: {
    isExpanded: Boolean,
    folder: Folder
  },
  watch: {
    async isExpanded() {
      if (this.folder.isExpanded) {
        await this.ensureChildrenPopulated();
      }
    }
  },
  methods: {
    async ensureChildrenPopulated() {
      if (!this.childrenPopulated) {
        await this.populateChildren();
        this.childrenPopulated = true;
      }
    },
    async populateChildren() {
      const expansion = await folderClient.getFolderExpansion(this.folder.id);

      this.folder.addFolders(expansion.folders);
      this.folder.addFiles(expansion.files);
    },
    async submitEdit(newName) {
      await this.submitNodeEdit(this.folder, newName);
    },
    cancelEdit() {
      this.cancelNodeEdit(this.folder);
    },
    async delete() {
      await this.deleteNode(this.folder);
    }
  }
};
</script>