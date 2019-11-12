<template lang="pug">
.select-none.h-screen.inline-block.border-2.border-orange-500
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
  folder(:model="rootFolder")
</template>

<script>
import ImageButtonComponent from "./ImageButton";
import FolderComponent from "./Folder";
import { Folder } from "@/models/Folder";
import { File } from "@/models/File";
import { focusTracker } from "@/services/FocusTracking/FocusTrackingFactory";

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
      this.findClosestFolderToFocus().addFile(new File("New File"));
    },
    newFolder() {
      this.findClosestFolderToFocus().addFolder(new Folder("New Folder"));
    },
    findClosestFolderToFocus() {
      const currentNode = focusTracker.getFocusedNode();

      if (currentNode === null) {
        return this.rootFolder;
      } else if (currentNode instanceof File) {
        return currentNode.parent;
      } else {
        return currentNode;
      }
    }
  }
};
</script>