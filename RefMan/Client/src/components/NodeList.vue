<template lang="pug">
div
  <!-- TODO: UUID keys from database -->
  template(v-for="folder of model.folders")
    folder(:model="folder")
  template(v-for="file of model.files")
    file(:model="file")
</template>

<script>
import FileComponent from "./File";
import { Folder } from "@/models/Folder";

export default {
  components: {
    folder: () => import("./Folder"),
    file: FileComponent
  },
  props: {
    model: Folder
  }
};
</script>