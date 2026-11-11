public class Solution
{
    public string MinWindow(string s, string t)
    {
        Dictionary<char, int> countT = new();
        Dictionary<char, int> window = new();

        foreach (char c in t)
        {
            if (countT.ContainsKey(c))
                countT[c]++;
            else
                countT[c] = 1;
        }

        int have = 0;
        int need = countT.Count;

        int left = 0;
        int minLen = int.MaxValue;
        int start = 0;

        for (int right = 0; right < s.Length; right++)
        {
            char c = s[right];

            if (window.ContainsKey(c))
                window[c]++;
            else
                window[c] = 1;

            if (countT.ContainsKey(c) &&
                window[c] == countT[c])
            {
                have++;
            }

            while (have == need)
            {
                if ((right - left + 1) < minLen)
                {
                    minLen = right - left + 1;
                    start = left;
                }

                window[s[left]]--;

                if (countT.ContainsKey(s[left]) &&
                    window[s[left]] < countT[s[left]])
                {
                    have--;
                }

                left++;
            }
        }

        return minLen == int.MaxValue
            ? ""
            : s.Substring(start, minLen);
    }
}