<template lang="pug">
.inline-block.select-none.w-full.h-full(
  @click.self="removeFocus"
)
  .bg-gray-200
    c-image-button(
      src="/img/new-file.png"
      tooltipText="New File"
      :disabled="!canCreateFile"
      @click="newFile"
    )
    c-image-button(
      src="/img/new-folder.png"
      tooltipText="New Folder"
      :disabled="!canCreateFolder"
      @click="newFolder"
    )
    c-image-button(
      src="/img/rename.png"
      tooltipText="Rename Selected"
      :disabled="!canEdit"
      @click="renameNode"
    )
    c-image-button(
      src="/img/delete.png"
      tooltipText="Delete Selected"
      :disabled="!canDelete"
      @click="showDeleteDialog"
    )
  c-node-list(v-if="rootFolder" :model="rootFolder")
  c-dialog(
    v-if="deleteDialogOpen"
    title="Are you sure?"
    :isOpen="deleteDialogOpen"
    @ok="deleteNode"
    @cancel="deleteDialogOpen = false"
  )
    p
      | Delete folder
      |
      span.font-semibold {{ focal.node.name }}
      | ?
</template>

<script>
import DialogComponent from "@/components/shared/Dialog";
import ImageButtonComponent from "@/components/references/file-system/ImageButton";
import NodeListComponent from "./NodeList";
import { Folder } from "@/models/file-tree/Folder";
import { File } from "@/models/file-tree/File";
import { createFocusManager } from "@/services/focus-tracking/FocusTrackingFactory";
import { folderClient } from "@/services/api-clients/FolderClient";

export default {
  components: {
    "c-dialog": DialogComponent,
    "c-image-button": ImageButtonComponent,
    "c-node-list": NodeListComponent
  },
  provide() {
    return {
      focusManager: this.focusManager
    };
  },
  data() {
    return {
      focal: null,
      rootFolder: null,
      deleteDialogOpen: false
    };
  },
  computed: {
    canCreateFile() {
      return this.focalAcceptsChildren;
    },
    canCreateFolder() {
      return this.focalAcceptsChildren;
    },
    canEdit() {
      return this.focal && !this.focal.node.isEditing;
    },
    canDelete() {
      return this.focal;
    },
    focalAcceptsChildren() {
      return !this.focal || this.focal.node.existsInPersistentStore;
    }
  },
  beforeCreate() {
    this.focusManager = createFocusManager(this);
  },
  async created() {
    const rootFolderResult = await folderClient.getRoot();
    this.rootFolder = Folder.fromRootFolderResult(rootFolderResult);
  },
  methods: {
    onFocusChanged(focal) {
      this.focal = focal;
    },
    removeFocus() {
      this.focusManager.removeFocus();
    },
    newFile() {
      this.addNewNode(File.new(), (folder) => folder.addFile.bind(folder));
    },
    newFolder() {
      this.addNewNode(Folder.new(), (folder) => folder.addFolder.bind(folder));
    },
    renameNode() {
      this.focal.node.beginEditing();
    },
    showDeleteDialog() {
      this.deleteDialogOpen = true;
    },
    async deleteNode() {
      this.deleteDialogOpen = false;

      const focal = this.focal;

      this.removeFocus();

      const currentNode = focal.node;
      const currentNodeParent = currentNode.parent;
      currentNodeParent.remove(currentNode);

      if (currentNode.existsInPersistentStore) {
        await focal.deletable.delete();
      }
    },
    addNewNode(node, addFunction) {
      const closestFolderToFocus = this.findClosestFolderToFocus();
      closestFolderToFocus.allowExpansion();
      closestFolderToFocus.expand();

      node.beginEditing();

      addFunction(closestFolderToFocus)(node);
    },
    findClosestFolderToFocus() {
      const currentFocal = this.focal;

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