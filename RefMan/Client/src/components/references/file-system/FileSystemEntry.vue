<template lang="pug">
.inline-flex
  .flex.flex-none.expander.px-1(@click="toggleExpansion")
    .self-center.bg-cover.expand-image(
      :class="[{ invisible: !canExpand }, isExpandedLocal ? 'expanded' : 'collapsed']"
    )
  .inline-flex.px-1(
    :class="isSelected ? 'bg-blue-300' : 'hover-bg-blue-200'"
    @click="click"
    @dblclick="toggleExpansion"
  )
    img.flex-none(
      :src="isExpandedLocal ? imageExpanded : image"
      alt=""
      height="25"
      width="25"
    )
    p.flex-1(v-show="!isEditing") {{ node.name }}
    input.flex-1.outline-none.bg-transparent.border.border-solid.border-black(
      v-show="isEditing"
      ref="nameInput"
      type="text"
      v-model="node.name"
      @keyup.enter="stopEditing"
      @keyup.esc="stopEditing"
    )
</template>

<script>
import { Node } from "@/models/file-tree/Node";

export default {
  inject: [
    "focusManager",
    "parent"
  ],
  props: {
    image: String,
    imageExpanded: String,
    canExpand: Boolean,
    isExpanded: Boolean,
    node: Node
  },
  data() {
    return {
      isSelected: false
    };
  },
  computed: {
    isExpandedLocal() {
      return this.canExpand && this.isExpanded;
    },
    isEditing() {
      return this.node.isEditing;
    }
  },
  watch: {
    isEditing(value) {
      this.beginEditIfEditing();

      if (!value) {
        this.finishedEditing();
      }
    }
  },
  mounted() {
    this.beginEditIfEditing();
  },
  beforeDestroy() {
    if (this.isSelected) {
      this.focusManager.removeFocus();
    }
  },
  methods: {
    stopEditing() {
      this.node.stopEditing();
    },
    click() {
      this.focusSelf();
    },
    focus() {
      this.isSelected = true;
    },
    removeFocus() {
      this.isSelected = false;
      this.node.stopEditing();
    },
    focusSelf() {
      if (!this.isSelected) {
        this.focusManager.focus({
          focusable: this,
          deletable: this.parent,
          node: this.node
        });
      }
    },
    beginEditIfEditing() {
      if (this.isEditing) {
        this.focusSelf();
        this.$nextTick(() => {
          this.$refs.nameInput.focus();
          this.$refs.nameInput.setSelectionRange(0, this.node.name.length);
        });
      }
    },
    toggleExpansion() {
      this.$emit("toggleExpansion");
    },
    finishedEditing() {
      this.$emit("finishedEditing");
    }
  }
};
</script>

<style lang="stylus" scoped>
.expander
  .expand-image
    width: 8px
    height: 12px

    &.collapsed
      background-image: url("/img/expand.svg")

    &.expanded
      background-image: url("/img/expanded.svg")

  &:hover
    .expand-image
      &.collapsed
        background-image: url("/img/expand-select.svg")

      &.expanded
        background-image: url("/img/expanded-select.svg")
</style>