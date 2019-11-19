<template lang="pug">
button.group.relative.focus-outline-none.mx-1
  img(
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
    tooltipText: String
  }
};
</script>