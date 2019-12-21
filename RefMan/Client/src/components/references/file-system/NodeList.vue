<template lang="pug">
ol
  template(v-for="folder of model.folders")
    c-folder(:key="folder.id" :model="folder")
  template(v-for="file of model.files")
    c-file(:key="file.id" :model="file")
</template>

<script>
import FileComponent from "./File";
import { Folder } from "@/models/file-tree/Folder";

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