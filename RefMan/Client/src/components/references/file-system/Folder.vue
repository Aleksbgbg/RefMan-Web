<template lang="pug">
div
  c-file-system-entry(
    :image="require('@/assets/folder.svg')"
    :imageExpanded="require('@/assets/open-folder.svg')"
    :canExpand="canExpand"
    :isExpanded="isExpanded"
    :node="model"
    @expand="expand"
  )
  .ml-5(v-if="canExpand" v-show="isExpanded")
    c-node-list(:model="model")
</template>

<script>
import FileSystemEntryComponent from "./FileSystemEntry";
import { Folder } from "@/models/Folder";

export default {
  components: {
    "c-file-system-entry": FileSystemEntryComponent,
    "c-node-list": () => import("./NodeList")
  },
  props: {
    model: Folder
  },
  data() {
    return {
      isExpanded: true
    };
  },
  computed: {
    canExpand() {
      return this.model.folders.length > 0 || this.model.files.length > 0;
    }
  },
  methods: {
    expand() {
      if (this.canExpand) {
        this.isExpanded = !this.isExpanded;
      }
    }
  }
};
</script>