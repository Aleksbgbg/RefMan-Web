<template lang="pug">
div
  .flex.border-b-2
    template(v-for="item of items")
      c-tab-item(
        :key="item.id"
        :item="item"
        :isSelected="item.id === selectedItem.id"
        v-slot="{ isSelected }"
        @selected="selectedItem = item"
        @close="onClose"
      )
        slot(
          name="header"
          :item="item"
          :isSelected="isSelected"
        )
  template(v-if="selectedItem !== null")
    slot(:item="selectedItem")
</template>

<script>
import TabItemComponent from "@/components/shared/tab-control/TabItem";

export default {
  components: {
    "c-tab-item": TabItemComponent
  },
  props: {
    items: Array
  },
  data() {
    return {
      selectedItem: this.findNextItemToSelect()
    };
  },
  watch: {
    items() {
      if (this.items.length > 0 && this.selectedItem === null) {
        this.selectedItem = this.items[0];
      }
    }
  },
  methods: {
    select(item) {
      this.selectedItem = item;
    },
    onClose(item) {
      this.$emit("close", item);

      if (this.items.length === 0) {
        this.selectedItem = null;
      } else if (item === this.selectedItem) {
        this.selectedItem = this.findNextItemToSelect();
      }
    },
    findNextItemToSelect() {
      return this.items[0] || null;
    }
  }
};
</script>