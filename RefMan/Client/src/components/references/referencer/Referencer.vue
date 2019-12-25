<template lang="pug">
c-tab-control(
  :items="files"
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
    c-document(:file="item")
</template>

<script>
import TabControlComponent from "@/components/references/referencer/TabControl";
import DocumentComponent from "@/components/references/referencer/Document";

export default {
  components: {
    "c-tab-control": TabControlComponent,
    "c-document": DocumentComponent
  },
  data() {
    return {
      files: []
    };
  },
  methods: {
    close(file) {
      this.files.remove(file);
    }
  }
};
</script>