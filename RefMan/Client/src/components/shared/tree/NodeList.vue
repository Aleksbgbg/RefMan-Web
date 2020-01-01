<template lang="pug">
ol
  template(v-for="branch of branch.branches")
    c-branch(
      :key="branch.id"
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
  template(v-for="leaf of branch.leaves")
    c-leaf(
      :key="leaf.id"
      :leaf="leaf"
    )
      slot(
        name="leaf"
        :leaf="leaf"
      )
</template>

<script>
import LeafComponent from "@/components/shared/tree/Leaf";
import { Branch } from "@/models/tree/Branch";

export default {
  components: {
    "c-branch": () => import("@/components/shared/tree/Branch"),
    "c-leaf": LeafComponent
  },
  props: {
    branch: Branch
  }
};
</script>