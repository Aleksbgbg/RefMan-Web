<template lang="pug">
li.hover-bg-gray-200.px-5.py-1
  template(v-if="$attrs.to")
    router-link(v-bind="$attrs")
      slot
  template(v-else)
    slot
</template>