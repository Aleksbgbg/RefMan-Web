<template lang="pug">
c-card.max-w-xs.mx-auto.mt-4
  h4.text-2xl {{ title }}
  c-form(@submit="$emit('submit')")
    slot
    c-form-submit-button
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
    title: String
  }
};
</script>