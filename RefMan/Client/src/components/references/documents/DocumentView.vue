<template lang="pug">
c-tab-control(
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
  methods: {
    close(document) {
      this.documents.remove(document);
    }
  }
};
</script>