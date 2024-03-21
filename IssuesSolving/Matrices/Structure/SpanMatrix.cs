namespace IssuesSolving.Matrices.Structure
{
    public static class SpanMatrix
    {
        public static void Print<T>(this Span<T> span) where T : struct
        {
            Console.WriteLine();
            Console.Write("[ ");
            for (int i = 0; i < span.Length; i++)
            {
                Console.Write(span[i]);
                Console.Write(" ");
            }
            Console.Write("]");
            Console.WriteLine();
        }
    }
}
