<template lang="pug">
.h-full <!-- Placeholder div to separate Main.vue .grid class from this .grid class -->
  .grid.h-full
    section.min-h-0
      c-file-tree
    section.min-h-0
      c-referencer
</template>

<script>
import AllowAccessWhenLoggedInMixin from "@/mixins/access-control/AllowAccessWhenLoggedIn";
import FileTreeComponent from "./file-system/FileTree";
import ReferencerComponent from "./referencer/Referencer";

export default {
  mixins: [
    AllowAccessWhenLoggedInMixin
  ],
  components: {
    "c-file-tree": FileTreeComponent,
    "c-referencer": ReferencerComponent
  }
};
</script>

<style lang="stylus" scoped>
.grid
  display: grid
  grid-template-columns: 1fr 3fr
</style>