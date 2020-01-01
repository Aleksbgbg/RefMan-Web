export function createNodePersist(
  nodeClient,
  nodeFactory
) {
  async function createNode(node, name) {
    if (!node.parentId) {
      throw new Error("Trying to create a root node (not allowed as these are pre-populated).");
    }

    const createdNode = await nodeClient.createNode({
      parentIdString: node.parentId,
      name
    });

    const nodeParent = node.parent;
    const newNode = nodeFactory.createNodeFromIdAndName(createdNode.idString, createdNode.name);

    nodeParent.remove(node);
    nodeParent.add(newNode);
  }

  async function renameNode(node, newName) {
    const nodeResult = await nodeClient.updateNode(node.id, newName);
    node.name = nodeResult.name;
  }

  function isValidNewName(newName) {
    return newName !== "";
  }

  function cancelNodeCreation(node) {
    node.parent.remove(node);
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
      },
      async deleteNode(node) {
        await nodeClient.deleteNode(node.id);
      }
    }
  };
}