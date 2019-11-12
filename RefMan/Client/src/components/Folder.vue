<template lang="pug">
div
  file-system-entry(
    :image="require('@/assets/folder.svg')"
    :imageExpanded="require('@/assets/open-folder.svg')"
    :name="model.name"
    :canExpand="canExpand"
    :isExpanded="isExpanded"
    :node="model"
    @dblclick.native="doubleClick"
  )
  .ml-5(v-if="canExpand" v-show="isExpanded")
    node-list(:model="model")
</template>

<script>
import FileSystemEntryComponent from "./FileSystemEntry";
import { Folder } from "@/models/Folder";

export default {
  components: {
    "file-system-entry": FileSystemEntryComponent,
    "node-list": () => import("./NodeList")
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
    doubleClick() {
      if (this.canExpand) {
        this.isExpanded = !this.isExpanded;
      }
    }
  }
};
</script>