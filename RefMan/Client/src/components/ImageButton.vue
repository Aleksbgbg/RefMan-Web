<template lang="pug">
button.group.inline-block.relative.border.border-dotted.border-black
  img(
    :src="src"
    alt=""
    width="25"
    height="25"
  )
  span.invisible.bg-black.text-white.text-center.px-3.rounded.absolute(class="group-hover:visible") {{ tooltipText }}
</template>

<script>
export default {
  props: {
    src: String,
    tooltipText: String
  }
};
</script>