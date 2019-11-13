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
  p(v-show="!isEditing") {{ node.name }}
  input.outline-none.bg-transparent.border.border-solid.border-black(
    v-show="isEditing"
    type="text"
    v-model="node.name"
    ref="nameInput"
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
    isEditing() {
      this.beginEditIfEditing();
    }
  },
  mounted() {
    this.beginEditIfEditing();
  },
  methods: {
    click() {
      if (!this.isSelected) {
        this.focusSelf();
      }
    },
    focus() {
      this.isSelected = true;
    },
    removeFocus() {
      this.isSelected = false;
      this.node.isEditing = false;
    },
    edit() {
      this.node.isEditing = true;
    },
    focusSelf() {
      focusManager.focus({
        focusable: this,
        editable: this,
        node: this.node
      });
    },
    beginEditIfEditing() {
      if (this.isEditing) {
        this.focusSelf();
        this.$nextTick(() => {
          this.$refs.nameInput.focus();
        });
      }
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