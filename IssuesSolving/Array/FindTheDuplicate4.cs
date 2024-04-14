namespace IssuesSolving.Array
{
    public static class FindTheDuplicate4
    {
        public static int FindFirst(int[] arr)
        {
            var hashset = new HashSet<int>(arr.Length);

            for (int i = 0; i < arr.Length; i++)
            {
                if (hashset.Contains(arr[i]))
                    return arr[i];
                else
                    hashset.Add(arr[i]);
            }

            throw new Exception("There is supposed to be a duplicate in the arr!");
        }
    }
}
