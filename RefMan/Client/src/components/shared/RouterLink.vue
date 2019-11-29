<template lang="pug">
router-link.text-blue-500.hover-text-blue-700.hover-underline(v-bind="$attrs")
  slot
</template>

<script>
export default {
  inheritAttrs: false
};
</script>