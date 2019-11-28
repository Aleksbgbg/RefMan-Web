<template lang="pug">
div
  <!-- TODO: UUID keys from database -->
  template(v-for="folder of model.folders")
    c-folder(:key="folder.name" :model="folder")
  template(v-for="file of model.files")
    c-file(:key="file.name" :model="file")
</template>

<script>
import FileComponent from "./File";
import { Folder } from "@/models/Folder";

export default {
  components: {
    "c-folder": () => import("./Folder"),
    "c-file": FileComponent
  },
  props: {
    model: Folder
  }
};
</script>