<template lang="pug">
.flex(@dblclick="onDoubleClick")
  .w-px-25
    img(
      :src="image"
      alt=""
      height="25"
      width="25"
    )
  .ml-1
    span(v-show="!isEditing") {{ fileSystemEntry.name }}
    input.outline-none.bg-transparent.border.border-solid.border-black(
      v-if="isEditing"
      ref="nameInput"
      type="text"
      v-model="localName"
      @keyup.enter="onSubmitEdit"
      @keyup.esc="onCancelEdit"
    )
</template>

<script>
import { FileSystemEntry } from "@/models/file-tree/FileSystemEntry";

export default {
  inject: ["treeNode"],
  props: {
    image: String,
    fileSystemEntry: FileSystemEntry
  },
  data() {
    return {
      localName: this.fileSystemEntry.name
    };
  },
  computed: {
    isEditing() {
      return this.fileSystemEntry.isEditing;
    },
    isFocused() {
      return this.treeNode.isFocused;
    }
  },
  watch: {
    isEditing() {
      this.focusNameInputIfEditing();
    },
    isFocused() {
      if (this.isEditing && !this.isFocused) {
        this.onSubmitEdit();
      }
    }
  },
  mounted() {
    this.focusNameInputIfEditing();
  },
  methods: {
    focusNameInputIfEditing() {
      if (this.isEditing) {
        this.treeNode.focusSelf();
        this.$nextTick(() => {
          const nameInput = this.$refs.nameInput;

          nameInput.focus();
          nameInput.setSelectionRange(0, this.localName.length);
        });
      }
    },
    onSubmitEdit() {
      this.$emit("submitEdit", this.localName);
    },
    onCancelEdit() {
      this.localName = this.fileSystemEntry.name;
      this.$emit("cancelEdit");
    },
    onDoubleClick() {
      this.$emit("doubleClick");
    }
  }
};
</script>

<style lang="stylus" scoped>
.w-px-25
  width: 25px
</style>