<template lang="pug">
.flex.items-center.border-b-4.hover-bg-gray-200.px-2(
  :class="isSelected ? 'border-blue-400' : 'border-transparent'"
  @click="onSelect"
)
  slot(:isSelected="isSelected")
  c-font-awesome-icon.hover-text-red-500(
    icon="times"
    @click="onClose"
  )
</template>

<script>
import { library } from "@fortawesome/fontawesome-svg-core";
import { faTimes } from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/vue-fontawesome";

library.add(faTimes);

export default {
  components: {
    "c-font-awesome-icon": FontAwesomeIcon
  },
  props: {
    item: Object,
    isSelected: Boolean
  },
  methods: {
    onSelect() {
      this.$emit("selected", this.item);
    },
    onClose() {
      this.$emit("close", this.item);
    }
  }
};
</script>