namespace IssuesSolving.Array
{
    public static class RemoveDuplicates3
    {
        public static int[] Remove(int[] arr)
        {
            var hashset = new HashSet<int>(arr.Length);

            for (int i = 0; i < arr.Length; i++)
                hashset.Add(arr[i]);

            return hashset.ToArray();
        }
    }
}
