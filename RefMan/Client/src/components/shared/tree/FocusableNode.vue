<template lang="pug">
.flex-grow.px-1(
  :class="isFocused ? 'bg-blue-300' : 'hover-bg-blue-200'"
  @click="onClick"
  @dblclick="onDoubleClick"
)
  slot
</template>

<script>
import { Node } from "@/models/tree/Node";

export default {
  provide() {
    return {
      treeNode: this
    };
  },
  inject: ["focusManager"],
  props: {
    node: Node
  },
  data() {
    return {
      isFocused: false
    };
  },
  beforeDestroy() {
    if (this.isFocused) {
      this.focusManager.removeFocus();
    }
  },
  methods: {
    onClick() {
      this.$emit("click");
      this.focusSelf();
    },
    onDoubleClick() {
      this.$emit("doubleClick");
    },
    focusSelf() {
      if (!this.isFocused) {
        this.focusManager.focus({
          focusable: this,
          node: this.node
        });
      }
    },
    focus() {
      this.isFocused = true;
    },
    removeFocus() {
      this.isFocused = false;
    }
  }
};
</script>