<template lang="pug">
button.group.relative.mx-1(class="focus:outline-none")
  img(
    :src="src"
    alt=""
    width="25"
    height="25"
  )
  span.invisible.bg-black.text-white.text-center.text-xs.px-2.rounded.absolute(class="group-hover:visible") {{ tooltipText }}
</template>

<script>
export default {
  props: {
    src: String,
    tooltipText: String
  }
};
</script>