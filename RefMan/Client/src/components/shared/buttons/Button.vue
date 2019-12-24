<template lang="pug">
c-button-no-padding.py-2.px-4(v-bind="$attrs" @click="$emit('click')")
  slot
</template>

<script>
import ButtonNoPaddingComponent from "@/components/shared/buttons/ButtonNoPadding";

export default {
  inheritAttrs: false,
  components: {
    "c-button-no-padding": ButtonNoPaddingComponent
  }
};
</script>