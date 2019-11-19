<template lang="pug">
router-link.mx-2(
  v-slot="{ href, navigate, isActive }"
  v-bind="$attrs"
)
  a(
    :class="isActive ? 'text-white' : 'text-gray-400 hover-text-gray-200'"
    :href="href"
    @click="navigate"
  )
    slot
</template>