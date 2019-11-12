<template lang="pug">
.inline-flex.px-1(
  class="hover:bg-blue-200"
  :class="{ 'bg-blue-300': isSelected }"
  @click="click"
)
  .bg-cover.self-center.expand-image(
    v-if="canExpand"
    :class="{ expanded: isExpandedLocal, collapsed: !isExpandedLocal }"
  )
  img(
    :src="isExpandedLocal ? imageExpanded : image"
    alt=""
    height="25"
    width="25"
  )
  p {{ name }}
</template>

<script>
import { Node } from "@/models/Node";
import { focusManager } from "@/services/FocusTracking/FocusTrackingFactory";

export default {
  props: {
    image: String,
    imageExpanded: String,
    name: String,
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
    }
  },
  methods: {
    click() {
      if (this.isSelected) {
        focusManager.removeFocus();
      } else {
        focusManager.focus(this, this.node);
      }
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