public class Solution
{
    public int[] TopKFrequent(int[] nums, int k)
    {
        Dictionary<int, int> freq = new Dictionary<int, int>();

        foreach (int num in nums)
        {
            if (freq.ContainsKey(num))
                freq[num]++;
            else
                freq[num] = 1;
        }

        List<KeyValuePair<int, int>> list =
            new List<KeyValuePair<int, int>>(freq);

        list.Sort((a, b) => b.Value.CompareTo(a.Value));

        int[] result = new int[k];

        for (int i = 0; i < k; i++)
        {
            result[i] = list[i].Key;
        }

        return result;
    }
}