<template lang="pug">
button.group.relative.focus-outline-none.mx-1(
  :disabled="disabled"
  :class="{ 'cursor-not-allowed': disabled }"
  @click="emitClick"
)
  img(
    :class="{ 'opacity-50': disabled }"
    :src="image"
    alt=""
    width="25"
    height="25"
  )
  span.invisible.bg-black.text-white.text-center.text-xs.rounded.absolute.group-hover-visible.px-2 {{ tooltipText }}
</template>

<script>
export default {
  props: {
    image: String,
    tooltipText: String,
    disabled: Boolean
  },
  methods: {
    emitClick() {
      if (!this.disabled) {
        this.$emit("click");
      }
    }
  }
};
</script>