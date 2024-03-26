namespace Coding.Challenges.DataStructures.Array_Manipulation;

public class ArrayManipulation
{
    public static void Main(string[] args)
    {
        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(firstMultipleInput[0]);

        int m = Convert.ToInt32(firstMultipleInput[1]);

        List<List<int>> queries = new List<List<int>>();

        for (int i = 0; i < m; i++)
        {
            queries.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(queriesTemp => Convert.ToInt32(queriesTemp)).ToList());
        }

        long result = Result.arrayManipulation(n, queries);

        Console.WriteLine(result);
    }
}

class Result
{
    public static long arrayManipulation(int n, List<List<int>> queries)
    {
        if (n < 3 || n > Math.Pow(10, 7))
        {
            throw new ArgumentOutOfRangeException(nameof(n));
        }

        if (queries == null)
        {
            throw new ArgumentNullException(nameof(queries));
        }

        long[] arr = new long[n + 1];

        foreach (var query in queries)
        {
            int a = query[0];
            int b = query[1];
            int k = query[2];

            arr[a - 1] += k;
            arr[b] -= k;
        }


        long max = 0;
        long prefixSum = 0;

        foreach (long value in arr)
        {
            prefixSum += value;
            max = Math.Max(max, prefixSum);
        }

        return max;
    }

}
