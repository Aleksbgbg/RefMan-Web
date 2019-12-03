<template lang="pug">
c-file-tree
</template>

<script>
import AllowAccessWhenLoggedInMixin from "@/mixins/access-control/AllowAccessWhenLoggedIn";
import FileTreeComponent from "./file-system/FileTree";

export default {
  mixins: [
    AllowAccessWhenLoggedInMixin
  ],
  components: {
    "c-file-tree": FileTreeComponent
  }
};
</script>