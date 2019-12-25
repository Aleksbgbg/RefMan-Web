<template lang="pug">
c-tab-control(
  ref="tabControl"
  :items="documents"
  @close="close"
)
  template(#header="{ item, isSelected }")
    img(
      src="/img/file.svg"
      alt=""
      width="25"
      height="25"
    )
    span.ml-1.mr-2(
      :class="{ 'text-blue-500': isSelected }"
    ) {{ item.name }}
  template(v-slot="{ item }")
    c-document(:document="item")
</template>

<script>
import TabControlComponent from "@/components/shared/tab-control/TabControl";
import DocumentComponent from "@/components/references/documents/Document";
import { createTabPropagator } from "@/services/tab-propagation/TabPropagatorFactory";

export default {
  components: {
    "c-tab-control": TabControlComponent,
    "c-document": DocumentComponent
  },
  data() {
    return {
      documents: []
    };
  },
  created() {
    createTabPropagator(this);
  },
  methods: {
    open(tab) {
      const document = tab.document;

      if (!this.documents.includes(document)) {
        this.documents.push(document);
      }

      this.selectTab(document);
    },
    close(document) {
      this.documents.remove(document);
    },
    selectTab(document) {
      this.$refs.tabControl.select(document);
    }
  }
};
</script>