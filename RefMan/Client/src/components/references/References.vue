<template lang="pug">
c-file-tree
</template>

<script>
import PreventEntryWhenNotLoggedInMixin from "@/mixins/PreventEntryWhenNotLoggedIn";
import FileTreeComponent from "./file-system/FileTree";

export default {
  mixins: [
    PreventEntryWhenNotLoggedInMixin
  ],
  components: {
    "c-file-tree": FileTreeComponent
  }
};
</script>