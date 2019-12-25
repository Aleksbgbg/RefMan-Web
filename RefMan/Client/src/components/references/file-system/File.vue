<template lang="pug">
li
  c-file-system-entry(
    image="/img/file.svg"
    :canExpand="false"
    :node="model"
    @doubleClick="openTab"
    @submitEdit="submitEdit"
    @cancelEdit="cancelEdit"
  )
</template>

<script>
import FilePersistMixin from "@/mixins/node-persistence/FilePersist";
import FileSystemEntryComponent from "./FileSystemEntry";
import { File } from "@/models/file-tree/File";
import { acquireTabPropagator } from "@/services/tab-propagation/TabPropagatorFactory";

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
  data() {
    return {
      document: {
        id: this.model.id,
        name: this.model.name
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