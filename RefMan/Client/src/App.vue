<template lang="pug">
div#app
  file-tree
</template>

<script>
import FileTree from "./components/file-system/FileTree";

export default {
  components: {
    "file-tree": FileTree
  }
};
</script>

<style lang="stylus">
#app
  font-family: "Avenir", Helvetica, Arial, sans-serif
  -webkit-font-smoothing: antialiased
  -moz-osx-font-smoothing: grayscale
</style>