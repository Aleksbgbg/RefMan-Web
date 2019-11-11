<template lang="pug">
div
  .inline-flex.px-1(
    class="hover:bg-blue-200"
    :class="{ 'bg-blue-300': isSelected }"
    @click="click"
    @dblclick="doubleClick"
  )
    .bg-cover.self-center.expand-image(:class="{ expanded: isExpanded, collapsed: !isExpanded }")
    img(
      src="https://img.icons8.com/color/344/folder-invoices.png"
      alt="folder"
      height="25"
      width="25"
    )
    p {{ identity.name }}
  .pl-5(v-if="identity.children" v-show="isExpanded")
    template(v-for="child of identity.children")
      template(v-if="child.children")
        folder(:identity="child")
      template(v-else)
        file(:identity="child")
</template>

<script>
import { FileSystemEntryIdentity } from "@/types/FileSystemEntryIdentity";
import { focusManager } from "@/services/FocusTracking/FocusManagerFactory";

export default {
  name: "folder",
  props: {
    identity: FileSystemEntryIdentity
  },
  data() {
    return {
      isExpanded: true,
      isSelected: false
    };
  },
  methods: {
    click() {
      focusManager.focus(this);
    },
    doubleClick() {
      this.isExpanded = !this.isExpanded;
    },
    focus() {
      this.isSelected = true;
    },
    removeFocus() {
      this.isSelected = false;
    }
  }
};
</script>

<style lang="stylus" scoped>
.expand-image
  width: 5px
  height: 10px

  &.collapsed
    background-image: url("../assets/expand.svg")

    &:hover
      background-image: url("../assets/expand-select.svg")

  &.expanded
    background-image: url("../assets/expanded.svg")

    &:hover
      background-image: url("../assets/expanded-select.svg")
</style>