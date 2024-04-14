namespace IssuesSolving.Array
{
    public static class FindPairThatSumsUpToK1
    {
        public static bool FindPair(int[] arr, int k)
        {
            var hashset = new HashSet<int>(arr.Length);
            
            for (int i = 0; i < arr.Length; i++)
            {
                if (hashset.Contains(k - arr[i]))
                    return true;
                else
                    hashset.Add(arr[i]);
            }

            return false;   
        }
    }
}
