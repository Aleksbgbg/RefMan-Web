<template lang="pug">
div
  file-system-entry(
    :image="require('@/assets/file.svg')"
    :canExpand="false"
    :node="model"
  )
</template>

<script>
import FileSystemEntryComponent from "./FileSystemEntry";
import { File } from "@/models/File";

export default {
  components: {
    "file-system-entry": FileSystemEntryComponent
  },
  props: {
    model: File
  }
};
</script>