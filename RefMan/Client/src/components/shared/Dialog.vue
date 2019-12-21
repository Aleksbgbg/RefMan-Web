<template lang="pug">
.fixed.top-0.left-0.w-screen.h-screen.z-50(
  v-show="isOpen"
)
  .absolute.w-full.h-full.bg-gray-900.opacity-50(@click.self="onCancel")
  .absolute.w-full
    .shadow-md.border.border-gray-500.rounded.w-px-400.bg-white.mx-auto.my-10
      header.p-3
        h5.text-lg.font-semibold {{ title }}
      hr
      .p-3.my-4
        slot
      hr
      footer.p-3
        .flex.justify-end
          gc-button.mx-1(variant="red" @click="onCancel") {{ cancelText }}
          gc-button.mx-1(@click="onOk") {{ okText }}
</template>

<script>
export default {
  props: {
    isOpen: Boolean,
    title: String,
    okText: {
      type: String,
      default: "OK"
    },
    cancelText: {
      type: String,
      default: "Cancel"
    }
  },
  methods: {
    onOk() {
      this.$emit("ok");
    },
    onCancel() {
      this.$emit("cancel");
    }
  }
};
</script>