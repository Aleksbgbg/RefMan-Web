<template lang="pug">
div
  h3.font-semibold {{ title }}
  cite.inline-block.select-all.not-italic.ml-2
    slot
</template>

<script>
export default {
  props: {
    title: String
  }
};
</script>