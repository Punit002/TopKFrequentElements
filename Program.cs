namespace TopKFrequentElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Solution.TopKFrequent(new int[] { 1, 1, 1, 2, 2, 3 }, 2);
            Console.ReadKey();
        }
    }


    public static class Solution
    {
        public static int[] TopKFrequent(int[] nums, int k)
        {
            Dictionary<int, int> result = new Dictionary<int, int>();

            List<int> returnResult = new ();

            foreach (var item in nums)
            {
                if(result.TryGetValue(item, out int value))
                {
                    result[item] = value + 1;
                }
                else
                {
                    result.Add(item, 1);
                }
            }

            result = result.OrderByDescending(item => item.Value).ToDictionary(x => x.Key, x => x.Value);

            int i = 0;

            foreach (var item in result)
            {
                if(i < k)
                {
                    returnResult.Add(item.Key);
                    i++;
                }
            }

            return returnResult.ToArray();
        }
    }
}