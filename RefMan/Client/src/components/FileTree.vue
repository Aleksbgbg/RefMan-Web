<template lang="pug">
.select-none.h-screen.inline-block.border-2.border-orange-500(
  @click.self="loseFocus"
)
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
    image-button.mx-1(
      :src="require('@/assets/rename.png')"
      tooltipText="Rename Selected"
      @click.native="renameNode"
    )
    image-button.mx-1(
      :src="require('@/assets/delete.png')"
      tooltipText="Delete Selected"
      @click.native="deleteNode"
    )
  div
    node-list(:model="rootFolder")
</template>

<script>
import ImageButtonComponent from "./ImageButton";
import NodeListComponent from "./NodeList";
import { Folder } from "@/models/Folder";
import { File } from "@/models/File";
import { focusManager, focusTracker } from "@/services/FocusTracking/FocusTrackingFactory";

const rootFolder = new Folder();
const assignmentFolder = new Folder("Assignments");
const otherFolder = new Folder("Some Other Folder");

rootFolder.addFolder(assignmentFolder);
rootFolder.addFolder(otherFolder);

assignmentFolder.addFile(new File("Part 1"));
assignmentFolder.addFile(new File("Part 2"));

export default {
  components: {
    "image-button": ImageButtonComponent,
    "node-list": NodeListComponent
  },
  data() {
    return {
      rootFolder
    };
  },
  methods: {
    loseFocus() {
      focusManager.removeFocus();
    },
    deleteNode() {
      const currentFocal = focusTracker.getFocal();

      const currentNode = currentFocal.node;
      const currentNodeParent = currentNode.parent;

      currentNodeParent.remove(currentNode);
    },
    renameNode() {
      const currentFocal = focusTracker.getFocal();
      currentFocal.node.isEditing = true;
    },
    newFile() {
      this.findClosestFolderToFocus().addFile(new File("New File", true));
    },
    newFolder() {
      this.findClosestFolderToFocus().addFolder(new Folder("New Folder", true));
    },
    findClosestFolderToFocus() {
      const currentFocal = focusTracker.getFocal();

      if (currentFocal === null) {
        return this.rootFolder;
      } else {
        const currentNode = currentFocal.node;

        if (currentNode.isLeaf) {
          return currentNode.parent;
        } else {
          return currentNode;
        }
      }
    }
  }
};
</script>