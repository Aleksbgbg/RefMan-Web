<template lang="pug">
li
  .flex
    .flex.items-center.expander.px-1(@click="toggleExpansion")
      .bg-cover.expand-image(
        :class="[{ 'invisible': !canExpand }, isExpanded ? 'expanded' : 'collapsed']"
      )
    c-focusable-node(
      :node="branch"
      @doubleClick="toggleExpansion"
    )
      slot(
        name="branch"
        :branch="branch"
        :isExpanded="isExpanded"
      )
  c-node-list.ml-5(
    v-show="isExpanded"
    :branch="branch"
  )
    template(#branch="{ branch, isExpanded }")
      slot(
        name="branch"
        :branch="branch"
        :isExpanded="isExpanded"
      )
    template(#leaf="{ leaf }")
      slot(
        name="leaf"
        :leaf="leaf"
      )
</template>

<script>
import FocusableNodeComponent from "@/components/shared/tree/FocusableNode";
import { Branch } from "@/models/tree/Branch";

export default {
  components: {
    "c-focusable-node": FocusableNodeComponent,
    "c-node-list": () => import("@/components/shared/tree/NodeList")
  },
  props: {
    branch: Branch
  },
  computed: {
    canExpand() {
      return this.branch.canExpand;
    },
    isExpanded() {
      return this.branch.isExpanded;
    }
  },
  methods: {
    toggleExpansion() {
      if (this.canExpand) {
        if (this.isExpanded) {
          this.branch.collapse();
        } else {
          this.branch.expand();
        }
      }
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