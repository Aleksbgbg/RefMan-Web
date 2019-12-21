<template lang="pug">
div
  c-file-system-entry(
    image="/img/file.svg"
    :canExpand="false"
    :node="model"
    @submitEdit="submitEdit"
    @cancelEdit="cancelEdit"
  )
</template>

<script>
import FilePersistMixin from "@/mixins/node-persistence/FilePersist";
import FileSystemEntryComponent from "./FileSystemEntry";
import { File } from "@/models/file-tree/File";
import { fileClient } from "@/services/api-clients/FileClient";

export default {
  mixins: [FilePersistMixin],
  components: {
    "c-file-system-entry": FileSystemEntryComponent
  },
  provide() {
    return {
      parent: this
    };
  },
  props: {
    model: File
  },
  methods: {
    async submitEdit(newName) {
      await this.submitNodeEdit(this.model, newName);
    },
    cancelEdit() {
      this.cancelNodeEdit(this.model);
    },
    async delete() {
      await fileClient.deleteFile(this.model.id);
    }
  }
};
</script>