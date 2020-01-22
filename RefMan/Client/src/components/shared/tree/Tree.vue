<template lang="pug">
.overflow-auto.whitespace-no-wrap
  c-node-list(:branch="rootBranch")
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
import NodeListComponent from "@/components/shared/tree/NodeList";
import { createFocusManager } from "@/services/focus-tracking/FocusTrackingFactory";
import { Branch } from "@/models/tree/Branch";

export default {
  components: {
    "c-node-list": NodeListComponent
  },
  provide() {
    return {
      focusManager: createFocusManager(this)
    };
  },
  props: {
    rootBranch: Branch
  },
  methods: {
    onFocusChanged(focal) {
      this.$emit("focusChanged", focal === null ? null : focal.node);
    }
  }
};
</script>