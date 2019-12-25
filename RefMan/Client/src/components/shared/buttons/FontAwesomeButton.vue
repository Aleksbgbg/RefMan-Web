<template lang="pug">
c-button-no-padding.group.px-2.py-1(
  variant="gray"
  @click="onClick"
)
  c-font-awesome-icon.text-gray-700.group-hover-text-gray-300(:icon="icon")
</template>

<script>
import ButtonNoPaddingComponent from "@/components/shared/buttons/ButtonNoPadding";
import { FontAwesomeIcon } from "@fortawesome/vue-fontawesome";

export default {
  components: {
    "c-button-no-padding": ButtonNoPaddingComponent,
    "c-font-awesome-icon": FontAwesomeIcon
  },
  props: {
    icon: String
  },
  methods: {
    onClick() {
      this.$emit("click");
    }
  }
};
</script>