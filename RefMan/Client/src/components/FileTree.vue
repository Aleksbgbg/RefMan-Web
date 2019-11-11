<template lang="pug">
.h-screen.inline-block.border-2.border-orange-500
  folder.select-none(:identity="rootFolderIdentity")
</template>

<script>
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
    "folder": Folder
  },
  data() {
    return {
      rootFolderIdentity
    };
  }
};
</script>