<template lang="pug">
.h-full(
  @click.self="removeFocus"
)
  .grid.h-full
    c-action-bar(
      :canCreateFolder="canCreateFolder"
      :canCreateFile="canCreateFile"
      :canEdit="canEdit"
      :canDelete="canDelete"
      @createFolder="createFolder"
      @createFile="createFile"
      @edit="editNode"
      @delete="beginDeleteNode"
    )
    c-file-tree(
      :rootFolder="rootFolder"
      @focusChanged="focusChanged"
    )
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
      span.font-semibold {{ focusedNode.name }}
      | ?
</template>

<script>
import ActionBarComponent from "@/components/references/file-system/actions/ActionBar";
import FileTreeComponent from "@/components/references/file-system/FileTree";
import DialogComponent from "@/components/shared/Dialog";
import { folderClient } from "@/services/api-clients/FolderClient";
import { folderFactory } from "@/services/FolderFactory";
import { fileFactory } from "@/services/FileFactory";

export default {
  components: {
    "c-action-bar": ActionBarComponent,
    "c-file-tree": FileTreeComponent,
    "c-dialog": DialogComponent
  },
  data() {
    return {
      rootFolder: null,
      focusedNode: null,
      deleteDialogOpen: false
    };
  },
  async created() {
    this.rootFolder = await folderClient.getRoot();
  },
  computed: {
    canCreateFolder() {
      return this.canCreateNodes;
    },
    canCreateFile() {
      return this.canCreateNodes;
    },
    canEdit() {
      return this.focusedNodeExists && !this.focusedNode.isEditing;
    },
    canDelete() {
      return this.focusedNodeExists;
    },
    canCreateNodes() {
      return !this.focusedNodeExists || // create at the root level
             this.focusedNode.isLeaf ||
             (this.focusedNode.isBranch && this.focusedNode.existsInPersistentStore);
    },
    focusedNodeExists() {
      return this.focusedNode !== null;
    }
  },
  methods: {
    focusChanged(node) {
      this.focusedNode = node;
    },
    removeFocus() {
      this.focusManager.removeFocus();
    },
    createFolder() {
      this.addNewFileSystemEntry(folderFactory.createPlaceholderNode(), (folder) => folder.addFolder.bind(folder));
    },
    createFile() {
      this.addNewFileSystemEntry(fileFactory.createPlaceholderNode(), (folder) => folder.addFile.bind(folder));
    },
    editNode() {
      this.focusedNode.beginEditing();
    },
    async beginDeleteNode() {
      if (this.focusedNode.existsInPersistentStore) {
        this.deleteDialogOpen = true;
      } else {
        await this.deleteNode();
      }
    },
    async deleteNode() {
      this.deleteDialogOpen = false;

      this.focusedNode.parent.remove(this.focusedNode);

      if (this.focusedNode.existsInPersistentStore) {
        if (this.focusedNode.isBranch) {
          await folderClient.deleteFolder(this.focusedNode.id);
        } else {
          await fileClient.deleteFile(this.focusedNode.id);
        }
      }
    },
    addNewFileSystemEntry(fileSystemEntry, getAddFunction) {
      const closestFolderToFocus = this.findClosestFolderToFocus();
      getAddFunction(closestFolderToFocus)(fileSystemEntry);

      closestFolderToFocus.expand();

      fileSystemEntry.beginEditing();
    },
    findClosestFolderToFocus() {
      if (this.focusedNode === null) {
        return this.rootFolder;
      } else if (this.focusedNode.isBranch) {
        return this.focusedNode;
      } else {
        return this.focusedNode.parent;
      }
    }
  }
};
</script>

<style lang="stylus" scoped>
.grid
  display: grid
  grid-template-rows: auto 1fr
</style>