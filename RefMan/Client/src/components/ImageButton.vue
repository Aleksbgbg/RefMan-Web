<template lang="pug">
button
  img(
    :src="src"
    alt=""
    width="25"
    height="25"
  )
</template>

<script>
export default {
  props: {
    src: String
  }
};
</script>