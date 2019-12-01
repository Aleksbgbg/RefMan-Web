<template lang="pug">
button.text-white.rounded.focus-outline-none.focus-shadow-outline.py-2.px-4(
  :class="[`bg-${variant}-${baseShade}`, disabled ? '' : `hover-bg-${variant}-${baseShade + 200}`]"
  :disabled="disabled"
)
  slot
</template>

<script>
export default {
  props: {
    variant: {
      type: String,
      default: "blue"
    },
    disabled: Boolean
  },
  computed: {
    baseShade() {
      return this.disabled ? 300 : 500;
    }
  }
};
</script>