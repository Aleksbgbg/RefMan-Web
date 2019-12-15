export function createNodePersist(
  createNode,
  updateNode,
  getSortNodesFunc
) {
  return {
    methods: {
      async finishedEditing() {
        const sort = () => {
          getSortNodesFunc(this.model.parent)();
        };

        if (this.model.existsInPersistentStore) {
          const nodeResult = await updateNode(this.model.id, this.model.name);

          this.model.name = nodeResult.name;

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