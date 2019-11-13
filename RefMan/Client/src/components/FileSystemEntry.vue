<template lang="pug">
.inline-flex.px-1(
  :class="isSelected ? 'bg-blue-300' : 'hover:bg-blue-200'"
  @click="click"
)
  .bg-cover.self-center.expand-image(
    v-if="canExpand"
    :class="isExpandedLocal ? 'expanded' : 'collapsed'"
  )
  img(
    :src="isExpandedLocal ? imageExpanded : image"
    alt=""
    height="25"
    width="25"
  )
  p(v-show="!isEditing") {{ name }}
  input.outline-none.bg-transparent.border.border-solid.border-black(
    v-show="isEditing"
    type="text"
    v-model="name"
  )
</template>

<script>
import { Node } from "@/models/Node";
import { focusManager } from "@/services/FocusTracking/FocusTrackingFactory";

export default {
  props: {
    image: String,
    imageExpanded: String,
    canExpand: Boolean,
    isExpanded: Boolean,
    node: Node
  },
  data() {
    return {
      isSelected: false,
      isEditing: false,
      name: this.node.name
    };
  },
  computed: {
    isExpandedLocal() {
      return this.canExpand && this.isExpanded;
    }
  },
  watch: {
    name() {
      this.node.name = this.name;
    }
  },
  methods: {
    click() {
      if (this.isSelected) {
        focusManager.removeFocus();
      } else {
        focusManager.focus({
          focusable: this,
          editable: this,
          node: this.node
        });
      }
    },
    focus() {
      this.isSelected = true;
    },
    removeFocus() {
      this.isSelected = false;
      this.isEditing = false;
    },
    edit() {
      this.isEditing = true;
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