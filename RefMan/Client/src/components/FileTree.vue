<template lang="pug">
div.m-10
  folder(name="a")
</template>

<script>
import Folder from "./Folder";

export default {
  components: {
    "folder": Folder
  }
};
</script>