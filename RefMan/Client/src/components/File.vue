<template lang="pug">
div
  file-system-entry(
    image="https://img.icons8.com/cute-clipart/344/file.png"
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