<template lang="pug">
div
  file-system-entry(
    :image="require('@/assets/file.svg')"
    :name="identity.name"
    :canExpand="false"
  )
</template>

<script>
import FileSystemEntry from "./FileSystemEntry";
import { FileSystemEntryIdentity } from "@/types/FileSystemEntryIdentity";

export default {
  components: {
    "file-system-entry": FileSystemEntry
  },
  props: {
    identity: FileSystemEntryIdentity
  }
};
</script>