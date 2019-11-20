<template lang="pug">
button.text-white.rounded.focus-outline-none.focus-shadow-outline.py-2.px-4(
  :class="`bg-${variant}-500 hover-bg-${variant}-700`"
)
  slot
</template>

<script>
export default {
  props: {
    variant: {
      type: String,
      default: "blue"
    }
  }
};
</script>