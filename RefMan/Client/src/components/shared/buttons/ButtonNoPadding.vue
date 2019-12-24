<template lang="pug">
button.text-white.rounded.focus-outline-none.focus-shadow-outline(
  :class="[`bg-${variant}-${baseShade}`, disabled ? '' : `hover-bg-${variant}-${baseShade + 200}`]"
  :disabled="disabled"
  @click="onClick"
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
  },
  methods: {
    onClick() {
      if (!this.disabled) {
        this.$emit("click");
      }
    }
  }
};
</script>