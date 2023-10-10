using IssuesSolving.Graphs.Structure;

namespace IssuesSolving.Graphs
{
    public static class GraphDepthFirstSearch23
    {
        public static int[] CalculateDepth(GraphNode root)
        {
            var list = new List<GraphNode>() { root };

            for (int i = 0; i < list.Count; i++)
            {
                var curent = list[i];
                foreach (var node in curent.Nodes)
                    if (!list.Contains(node))
                        list.Add(node);
            }

            return list.Select(x => x.Data).ToArray();
        }
    }
}
