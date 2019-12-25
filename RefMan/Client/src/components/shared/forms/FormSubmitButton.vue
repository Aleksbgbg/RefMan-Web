<template lang="pug">
c-button(type="submit" v-bind="$attrs")
  slot
</template>

<script>
import ButtonComponent from "@/components/shared/buttons/Button";

export default {
  inheritAttrs: false,
  components: {
    "c-button": ButtonComponent
  }
};
</script>