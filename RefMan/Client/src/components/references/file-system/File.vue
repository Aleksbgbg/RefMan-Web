<template lang="pug">
c-file-system-entry(
  image="/img/file.svg"
  :fileSystemEntry="file"
  @submitEdit="submitEdit"
  @cancelEdit="cancelEdit"
  @doubleClick="openTab"
)
</template>

<script>
import FilePersistMixin from "@/mixins/node-persistence/FilePersist";
import FileSystemEntryComponent from "@/components/references/file-system/FileSystemEntry";
import { File } from "@/models/file-tree/File";
import { acquireTabPropagator } from "@/services/tab-propagation/TabPropagatorFactory";

export default {
  mixins: [FilePersistMixin],
  components: {
    "c-file-system-entry": FileSystemEntryComponent
  },
  props: {
    file: File
  },
  data() {
    return {
      document: {
        id: this.file.id,
        name: this.file.name
      }
    };
  },
  created() {
    this.tabPropagator = acquireTabPropagator();
  },
  methods: {
    openTab() {
      this.tabPropagator.openTab({
        document: this.document
      });
    },
    async submitEdit(newName) {
      await this.submitNodeEdit(this.file, newName);
    },
    cancelEdit() {
      this.cancelNodeEdit(this.file);
    },
    async delete() {
      await this.deleteNode(this.file);
    }
  }
};
</script>