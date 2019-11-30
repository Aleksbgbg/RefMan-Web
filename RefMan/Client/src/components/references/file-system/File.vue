<template lang="pug">
div
  c-file-system-entry(
    image="/img/file.svg"
    :canExpand="false"
    :node="model"
  )
</template>

<script>
import FileSystemEntryComponent from "./FileSystemEntry";
import { File } from "@/models/file-tree/File";

export default {
  components: {
    "c-file-system-entry": FileSystemEntryComponent
  },
  props: {
    model: File
  }
};
</script>