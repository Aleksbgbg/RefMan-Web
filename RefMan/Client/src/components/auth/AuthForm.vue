<template lang="pug">
.w-full.max-w-sm.mx-auto.px-3.mt-4
  c-card
    h4.text-2xl {{ title }}
    c-form(@submit="$emit('submit')")
      slot
      c-form-submit-button(:disabled="isLoading")
        .inline-block.align-middle.loading.rounded-full.border-2.border-solid.border-white.h-3.w-3.mr-1(
          v-if="isLoading"
        )
        span Submit
      hr.my-3
      slot(name="footer")
</template>

<script>
import CardComponent from "@/components/shared/cards/Card";
import FormComponent from "@/components/shared/forms/Form";
import FormSubmitButtonComponent from "@/components/shared/forms/FormSubmitButton";

export default {
  components: {
    "c-card": CardComponent,
    "c-form": FormComponent,
    "c-form-submit-button": FormSubmitButtonComponent
  },
  props: {
    title: String,
    isLoading: Boolean
  }
};
</script>

<style lang="stylus">
.loading
  animation: spin 1s linear infinite
  border-right-color: transparent

  @keyframes spin
    to
      transform: rotate(360deg)
</style>