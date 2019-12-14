export function createNodePersist(
  createNode,
  getSortNodesFunc
) {
  return {
    methods: {
      async finishedEditing() {
        if (this.model.existsInPersistentStore) {
        } else {
          const nodeResult = await createNode({
            parentIdString: this.model.parentId,
            name: this.model.name
          });

          this.model.id = nodeResult.idString;
          this.model.name = nodeResult.name;
        }

        getSortNodesFunc(this.model.parent)();
      }
    }
  };
}