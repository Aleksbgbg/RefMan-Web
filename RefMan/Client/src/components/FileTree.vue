<template lang="pug">
div.m-10
  folder.select-none(name="a")
</template>

<script>
import Folder from "./Folder";

export default {
  components: {
    "folder": Folder
  }
};
</script>