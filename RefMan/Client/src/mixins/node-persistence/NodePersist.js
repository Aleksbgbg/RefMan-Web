export function createNodePersist(
  persistCreateNode,
  persistUpdateNode,
  getSortNodesFunc
) {
  function cancelNodeCreation(node) {
    node.parent.remove(node);
  }

  async function createNode(node, name) {
    const nodeResult = await persistCreateNode({
      parentIdString: node.parentId,
      name
    });

    node.id = nodeResult.idString;
    node.name = nodeResult.name;

    sortSubnodesByName(node.parent);
  }

  async function renameNode(node, newName) {
    const nodeResult = await persistUpdateNode(node.id, newName);

    node.name = nodeResult.name;

    sortSubnodesByName(node.parent);
  }

  function sortSubnodesByName(node) {
    getSortNodesFunc(node)();
  }

  function isValidNewName(newName) {
    return newName !== "";
  }

  return {
    methods: {
      async submitNodeEdit(node, newName) {
        if (node.existsInPersistentStore) {
          if (isValidNewName(newName)) {
            await renameNode(node, newName);
          }
        } else {
          if (isValidNewName(newName)) {
            await createNode(node, newName);
          } else {
            cancelNodeCreation(node);
          }
        }
      },
      cancelNodeEdit(node) {
        if (!node.existsInPersistentStore) {
          cancelNodeCreation(node);
        }
      }
    }
  };
}