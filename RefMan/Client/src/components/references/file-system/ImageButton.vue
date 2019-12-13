<template lang="pug">
button.relative.focus-outline-none.mx-1(
  :class="[disabled ? 'cursor-not-allowed' : 'group']"
  @click="emitClick"
)
  img(
    :class="{ 'opacity-50': disabled }"
    :src="src"
    alt=""
    width="25"
    height="25"
  )
  span.invisible.bg-black.text-white.text-center.text-xs.rounded.absolute.group-hover-visible.px-2 {{ tooltipText }}
</template>

<script>
export default {
  props: {
    src: String,
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