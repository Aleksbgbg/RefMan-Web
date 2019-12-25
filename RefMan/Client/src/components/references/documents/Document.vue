<template lang="pug">
.p-2
  c-search(placeholder="Enter a URL to reference" @search="search")
  .my-5
    template(v-for="reference of document.references")
      c-reference(:key="reference.id" :reference="reference")
</template>

<script>
import SearchComponent from "@/components/shared/Search";
import ReferenceComponent from "@/components/references/documents/Reference";
import { Document } from "@/models/referencing/Document";

export default {
  components: {
    "c-search": SearchComponent,
    "c-reference": ReferenceComponent
  },
  props: {
    document: Document
  },
  methods: {
    search(query) {
    }
  }
};
</script>