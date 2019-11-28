<template lang="pug">
form(@submit.prevent="$emit('submit')")
  slot
</template>