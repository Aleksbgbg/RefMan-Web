<template lang="pug">
.flex
  .flex.items-center.expander.px-1(@click="onToggleExpansion")
    .bg-cover.expand-image(
      :class="[{ invisible: !canExpand }, isExpandedLocal ? 'expanded' : 'collapsed']"
    )
  .flex.px-1(
    :class="isSelected ? 'bg-blue-300' : 'hover-bg-blue-200'"
    @click="click"
    @dblclick="onToggleExpansion"
  )
    .w-px-25
      img(
        :src="isExpandedLocal ? imageExpanded : image"
        alt=""
        height="25"
        width="25"
      )
    .ml-1
      span(v-show="!isEditing") {{ node.name }}
      input.outline-none.bg-transparent.border.border-solid.border-black(
        v-if="isEditing"
        ref="nameInput"
        type="text"
        v-model="nodeLocalName"
        @keyup.enter="submitEdit"
        @keyup.esc="cancelEdit"
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
      isSelected: false,
      nodeLocalName: this.node.name
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
      this.focusNameInputIfEditing();
    }
  },
  mounted() {
    this.focusNameInputIfEditing();
  },
  beforeDestroy() {
    if (this.isSelected) {
      this.focusManager.removeFocus();
    }
  },
  methods: {
    focusNameInputIfEditing() {
      if (this.isEditing) {
        this.focusSelf();
        this.$nextTick(() => {
          this.$refs.nameInput.focus();
          this.$refs.nameInput.setSelectionRange(0, this.node.name.length);
        });
      }
    },
    click() {
      this.focusSelf();
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
    focus() {
      this.isSelected = true;
    },
    removeFocus() {
      this.isSelected = false;
      if (this.isEditing) {
        this.submitEdit();
      }
    },
    submitEdit() {
      this.node.stopEditing();
      this.onSubmitEdit();
    },
    cancelEdit() {
      this.node.stopEditing();
      this.nodeLocalName = this.node.name;
      this.onCancelEdit();
    },
    onToggleExpansion() {
      if (this.node.canExpand) {
        this.$emit("toggleExpansion");
      }
    },
    onSubmitEdit() {
      this.$emit("submitEdit", this.nodeLocalName);
    },
    onCancelEdit() {
      this.$emit("cancelEdit");
    }
  }
};
</script>

<style lang="stylus" scoped>
.w-px-25
  width: 25px

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