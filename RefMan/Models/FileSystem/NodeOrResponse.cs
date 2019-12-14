namespace RefMan.Models.FileSystem
{
    using Microsoft.AspNetCore.Mvc;

    public class NodeOrResponse
    {
        public NodeOrResponse(Node node)
        {
            HasNode = true;
            Node = node;
        }

        public NodeOrResponse(ActionResult response)
        {
            HasNode = false;
            Response = response;
        }

        public bool HasNode { get; }

        public Node Node { get; }

        public ActionResult Response { get; }
    }
}