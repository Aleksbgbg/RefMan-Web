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
  .pl-5(v-if="canExpand" v-show="isExpanded")
    folder(v-for="folder of model.folders" :model="folder")
    file(v-for="file of model.files" :model="file")
</template>

<script>
import FileSystemEntryComponent from "./FileSystemEntry";
import FileComponent from "./File";
import { Folder } from "@/models/Folder";

export default {
  name: "folder",
  components: {
    "file-system-entry": FileSystemEntryComponent,
    file: FileComponent
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
      this.isExpanded = !this.isExpanded;
    }
  }
};
</script>