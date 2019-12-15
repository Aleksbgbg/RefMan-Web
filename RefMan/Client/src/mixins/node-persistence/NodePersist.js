export function createNodePersist(
  createNode,
  getSortNodesFunc
) {
  return {
    methods: {
      async finishedEditing() {
        const sort = () => {
          getSortNodesFunc(this.model.parent)();
        };

        if (this.model.existsInPersistentStore) {
          sort();
        } else if (this.model.name === "") {
          this.model.parent.remove(this.model);
        } else {
          const nodeResult = await createNode({
            parentIdString: this.model.parentId,
            name: this.model.name
          });

          this.model.id = nodeResult.idString;
          this.model.name = nodeResult.name;

          sort();
        }
      }
    }
  };
}