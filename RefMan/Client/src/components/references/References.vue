<template lang="pug">
.select-none.h-full <!-- Placeholder div to separate Main.vue .grid class from this .grid class -->
  .grid.h-full
    section.min-h-0
      c-file-tree
    section.min-h-0
      c-document-view
</template>

<script>
import AllowAccessWhenLoggedInMixin from "@/mixins/access-control/AllowAccessWhenLoggedIn";
import FileTreeComponent from "./file-system/FileTree";
import DocumentViewComponent from "./documents/DocumentView";

export default {
  mixins: [
    AllowAccessWhenLoggedInMixin
  ],
  components: {
    "c-file-tree": FileTreeComponent,
    "c-document-view": DocumentViewComponent
  }
};
</script>

<style lang="stylus" scoped>
.grid
  display: grid
  grid-template-columns: 1fr 3fr
</style>