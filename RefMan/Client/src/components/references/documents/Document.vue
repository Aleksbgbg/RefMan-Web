<template lang="pug">
.grid.h-full.px-2.pt-2
  c-search(placeholder="Enter a URL to reference" @search="search")
  .overflow-y-scroll.mt-2
    template(v-for="reference of document.references")
      c-reference(:key="reference.id" :reference="reference")
</template>

<script>
import SearchComponent from "@/components/shared/Search";
import ReferenceComponent from "@/components/references/documents/Reference";
import { Document } from "@/models/referencing/Document";
import { referencer } from "@/services/Referencer";

export default {
  components: {
    "c-search": SearchComponent,
    "c-reference": ReferenceComponent
  },
  props: {
    document: Document
  },
  methods: {
    async search(query) {
      await referencer.addReference(this.document, query);
    }
  }
};
</script>

<style lang="stylus" scoped>
.grid
  display: grid
  grid-template-rows: auto 1fr
</style>