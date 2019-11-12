<template lang="pug">
.h-screen.inline-block.border-2.border-orange-500
  .bg-gray-200
    image-button.mx-1(
      :src="require('@/assets/new-file.png')"
      tooltipText="New File"
      @click.native="newFile"
    )
    image-button.mx-1(
      :src="require('@/assets/new-folder.png')"
      tooltipText="New Folder"
      @click.native="newFolder"
    )
  folder.select-none(:model="rootFolder")
</template>

<script>
import ImageButtonComponent from "./ImageButton";
import FolderComponent from "./Folder";
import { Folder } from "@/models/Folder";
import { File } from "@/models/File";

const rootFolder = new Folder("Root");
const assignmentFolder = new Folder("Assignments");
const otherFolder = new Folder("Some Other Folder");

rootFolder.addFolder(assignmentFolder);
rootFolder.addFolder(otherFolder);

assignmentFolder.addFile(new File("Part 1"));
assignmentFolder.addFile(new File("Part 2"));

export default {
  components: {
    "image-button": ImageButtonComponent,
    folder: FolderComponent
  },
  data() {
    return {
      rootFolder
    };
  },
  methods: {
    newFile() {
      this.rootFolder.addFile(new File("New File"));
    },
    newFolder() {
      this.rootFolder.addFolder(new Folder("New Folder"));
    }
  }
};
</script>