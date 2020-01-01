<template lang="pug">
.bg-gray-200
  c-action-button(
    image="/img/new-folder.png"
    tooltipText="New Folder"
    :disabled="!canCreateFolder"
    @click="onCreateFolder"
  )
  c-action-button(
    image="/img/new-file.png"
    tooltipText="New File"
    :disabled="!canCreateFile"
    @click="onCreateFile"
  )
  c-action-button(
    image="/img/rename.png"
    tooltipText="Rename Selected"
    :disabled="!canEdit"
    @click="onEdit"
  )
  c-action-button(
    image="/img/delete.png"
    tooltipText="Delete Selected"
    :disabled="!canDelete"
    @click="onDelete"
  )
</template>

<script>
import ActionButtonComponent from "@/components/references/file-system/actions/ActionButton";

export default {
  components: {
    "c-action-button": ActionButtonComponent
  },
  props: {
    canCreateFolder: Boolean,
    canCreateFile: Boolean,
    canEdit: Boolean,
    canDelete: Boolean
  },
  methods: {
    onCreateFolder() {
      this.$emit("createFolder");
    },
    onCreateFile() {
      this.$emit("createFile");
    },
    onEdit() {
      this.$emit("edit");
    },
    onDelete() {
      this.$emit("delete");
    }
  }
};
</script>