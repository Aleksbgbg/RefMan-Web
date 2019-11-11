<template lang="pug">
.h-screen.inline-block.border-2.border-orange-500
  div
    image-button(
      :src="require('@/assets/new-file.png')"
      tooltipText="New File"
      @click.native="newFile"
    )
    image-button(
      :src="require('@/assets/new-folder.png')"
      tooltipText="New Folder"
      @click.native="newFolder"
    )
  folder.select-none(:identity="rootFolderIdentity")
</template>

<script>
import ImageButton from "./ImageButton";
import Folder from "./Folder";

const rootFolderIdentity = {
  name: "References",
  children: [
    {
      name: "Assignment",
      children: [
        {
          name: "Part 1"
        },
        {
          name: "Part 2"
        }
      ]
    },
    {
      name: "Some Other Folder",
      children: []
    }
  ]
};

export default {
  components: {
    "image-button": ImageButton,
    folder: Folder
  },
  data() {
    return {
      rootFolderIdentity
    };
  },
  methods: {
    newFile() {
      this.rootFolderIdentity.children.push({
        name: "New File"
      });
    },
    newFolder() {
      this.rootFolderIdentity.children.push({
        name: "New Folder",
        children: []
      });
    }
  }
};
</script>