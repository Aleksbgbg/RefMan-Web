<template lang="pug">
div
  c-file-system-entry(
    image="/img/file.svg"
    :canExpand="false"
    :node="model"
    @finishedEditing="finishedEditing"
  )
</template>

<script>
import FilePersistMixin from "@/mixins/node-persistence/FilePersist";
import FileSystemEntryComponent from "./FileSystemEntry";
import { File } from "@/models/file-tree/File";

export default {
  mixins: [FilePersistMixin],
  components: {
    "c-file-system-entry": FileSystemEntryComponent
  },
  props: {
    model: File
  }
};
</script>