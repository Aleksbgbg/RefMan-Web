<template lang="pug">
div.m-10
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