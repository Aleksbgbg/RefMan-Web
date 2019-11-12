<template lang="pug">
div
  file-system-entry(
    :image="require('@/assets/file.svg')"
    :name="model.name"
    :canExpand="false"
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