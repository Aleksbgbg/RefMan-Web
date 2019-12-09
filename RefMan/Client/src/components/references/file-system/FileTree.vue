<template lang="pug">
.select-none.h-screen.inline-block.border-2.border-orange-500(
  @click.self="loseFocus"
)
  .bg-gray-200
    c-image-button(
      src="/img/new-file.png"
      tooltipText="New File"
      @click.native="newFile"
    )
    c-image-button(
      src="/img/new-folder.png"
      tooltipText="New Folder"
      @click.native="newFolder"
    )
    c-image-button(
      src="/img/rename.png"
      tooltipText="Rename Selected"
      @click.native="renameNode"
    )
    c-image-button(
      src="/img/delete.png"
      tooltipText="Delete Selected"
      @click.native="deleteNode"
    )
  c-node-list(v-if="rootFolder" :model="rootFolder")
</template>

<script>
import ImageButtonComponent from "@/components/shared/buttons/ImageButton";
import NodeListComponent from "./NodeList";
import { Folder } from "@/models/file-tree/Folder";
import { File } from "@/models/file-tree/File";
import { createFocusTrackers } from "@/services/focus-tracking/FocusTrackingFactory";
import { fileSystemClient } from "@/services/api-clients/FileSystemClient";

const { focusManager, focusTracker } = createFocusTrackers();

export default {
  components: {
    "c-image-button": ImageButtonComponent,
    "c-node-list": NodeListComponent
  },
  provide: {
    focusManager
  },
  data() {
    return {
      rootFolder: null
    };
  },
  async created() {
    const rootFolderResult = await fileSystemClient.root();
    this.rootFolder = Folder.fromRootFolderResult(rootFolderResult);
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
      currentFocal.node.beginEditing();
    },
    newFile() {
      this.addNewNode(File.new(), (folder) => folder.addFile.bind(folder));
    },
    newFolder() {
      this.addNewNode(Folder.new(), (folder) => folder.addFolder.bind(folder));
    },
    addNewNode(node, addFunction) {
      const closestFolderToFocus = this.findClosestFolderToFocus();
      closestFolderToFocus.allowExpansion();
      closestFolderToFocus.expand();

      node.beginEditing();

      addFunction(closestFolderToFocus)(node);
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