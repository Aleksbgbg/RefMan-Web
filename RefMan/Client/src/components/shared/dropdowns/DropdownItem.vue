<template lang="pug">
div
  template(v-if="$attrs.to")
    router-link(v-bind="$attrs" @click.native="click")
      li.hover-bg-gray-200.px-5.py-1
        slot
  template(v-else)
    li.hover-bg-gray-200.px-5.py-1(@click="$emit('click')")
      slot
</template>

<script>
export default {
  inheritAttrs: false,
  inject: {
    dropdownMenu: {
      default: null
    }
  },
  methods: {
    click() {
      this.$nextTick(() => {
        this.dropdownMenu.hide();
      });
    }
  }
};
</script>