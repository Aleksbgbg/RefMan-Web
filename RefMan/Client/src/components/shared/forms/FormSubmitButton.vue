<template lang="pug">
gc-button(type="submit" v-bind="$attrs")
  slot
</template>

<script>
export default {
  inheritAttrs: false
};
</script>