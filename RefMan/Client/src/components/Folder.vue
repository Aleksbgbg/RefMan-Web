<template lang="pug">
div
  div.flex
    div.expand.self-center(:class="{ expanded: isExpanded, collapsed: !isExpanded }")
    img(src="https://img.icons8.com/color/344/folder-invoices.png" alt="folder" height="25" width="25")
    p hello
  folder.pl-5(v-if="isExpanded && name !== 'b'" :name="name === 'a' ? 'c' : 'b'")
</template>

<script>

export default {
  name: "folder",
  props: {
    name: String
  },
  data() {
    return {
      isExpanded: true
    };
  }
};
</script>

<style lang="stylus" scoped>
.expand
  width: 5px
  height: 10px
  background-size: cover

.collapsed
  background-image: url("../assets/expand.svg")

  &:hover
    background-image: url("../assets/expand-select.svg")

.expanded
  background-image: url("../assets/expanded.svg")

  &:hover
    background-image: url("../assets/expanded-select.svg")
</style>