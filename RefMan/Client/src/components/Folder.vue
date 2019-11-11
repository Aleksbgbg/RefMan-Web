<template lang="pug">
div
  file-system-entry(
    :image="require('@/assets/folder.svg')"
    :imageExpanded="require('@/assets/open-folder.svg')"
    :name="identity.name"
    :canExpand="identity.children.length > 0"
    :isExpanded="isExpanded"
    @dblclick.native="doubleClick"
  )
  .pl-5(v-if="identity.children" v-show="isExpanded")
    template(v-for="child of identity.children")
      template(v-if="child.children")
        folder(:identity="child")
      template(v-else)
        file(:identity="child")
</template>

<script>
import FileSystemEntry from "./FileSystemEntry";
import File from "./File";
import { FileSystemEntryIdentity } from "@/types/FileSystemEntryIdentity";

export default {
  name: "folder",
  components: {
    "file-system-entry": FileSystemEntry,
    file: File
  },
  props: {
    identity: FileSystemEntryIdentity
  },
  data() {
    return {
      isExpanded: true
    };
  },
  methods: {
    doubleClick() {
      this.isExpanded = !this.isExpanded;
    }
  }
};
</script>