<template lang="pug">
.relative
  c-button.dropdown-btn(@click.native="isOpen = !isOpen" @focusout.native="isOpen = false")
    slot(name="button-content")
  ul.absolute.align-right.rounded.bg-white.shadow.py-3(v-show="isOpen")
    slot
</template>

<script>
export default {
  data() {
    return {
      isOpen: false
    };
  }
};
</script>

<style lang="stylus" scoped>
.dropdown-btn:after
  display: inline-block
  content: ""
  vertical-align: .255em
  margin-left: .255em
  border-top: .3em solid
  border-right: .3em solid transparent
  border-left: .3em solid transparent

ul
  transform: translateY(.25rem)
</style>