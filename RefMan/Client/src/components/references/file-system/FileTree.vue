<template lang="pug">
c-tree(
  v-if="rootFolder"
  :rootBranch="rootFolder"
  @focusChanged="onFocusChanged"
)
  template(#branch="{ branch, isExpanded }")
    c-folder(
      :isExpanded="isExpanded"
      :folder="branch"
    )
  template(#leaf="{ leaf }")
    c-file(
      :file="leaf"
    )
</template>

<script>
import TreeComponent from "@/components/shared/tree/Tree";
import FolderComponent from "@/components/references/file-system/Folder";
import FileComponent from "@/components/references/file-system/File";
import { Folder } from "@/models/file-tree/Folder";

export default {
  components: {
    "c-tree": TreeComponent,
    "c-folder": FolderComponent,
    "c-file": FileComponent
  },
  props: {
    rootFolder: Folder
  },
  methods: {
    onFocusChanged(fileSystemEntry) {
      this.$emit("focusChanged", fileSystemEntry);
    }
  }
};
</script>