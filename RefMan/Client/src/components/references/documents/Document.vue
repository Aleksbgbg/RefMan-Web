<template lang="pug">
.p-2
  c-search(placeholder="Enter a URL to reference" @search="search")
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