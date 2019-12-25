<template lang="pug">
.p-2
  c-search(placeholder="Enter a URL to reference" @search="search")
  .my-5
    template(v-for="reference of references")
      c-reference(:reference="reference")
</template>

<script>
import SearchComponent from "@/components/references/referencer/Search";
import ReferenceComponent from "@/components/references/referencer/reference/Reference";

export default {
  components: {
    "c-search": SearchComponent,
    "c-reference": ReferenceComponent
  },
  props: {
    file: Object
  },
  data() {
    return {
      references: []
    };
  },
  methods: {
    search(query) {
    }
  }
};
</script>