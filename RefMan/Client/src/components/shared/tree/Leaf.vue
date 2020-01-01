<template lang="pug">
li
  .flex
    .context-box.w-px-8.px-1
    c-focusable-node(:node="leaf")
      slot(:leaf="leaf")
</template>

<script>
import FocusableNodeComponent from "@/components/shared/tree/FocusableNode";
import { Leaf } from "@/models/tree/Leaf";

export default {
  components: {
    "c-focusable-node": FocusableNodeComponent
  },
  props: {
    leaf: Leaf
  }
};
</script>

<style lang="stylus" scoped>
.content-box
  box-sizing: content-box

.w-px-8
  width: 8px
</style>