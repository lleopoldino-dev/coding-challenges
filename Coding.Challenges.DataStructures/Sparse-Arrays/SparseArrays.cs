namespace Coding.Challenges.DataStructures.Sparse_Arrays;

public class SparseArrays
{
    public static void Main(string[] args)
    {
        int stringListCount = Convert.ToInt32(Console.ReadLine()?.Trim() ?? "0");

        List<string> stringList = new List<string>();

        for (int i = 0; i < stringListCount; i++)
        {
            string stringListItem = Console.ReadLine() ?? "";
            stringList.Add(stringListItem);
        }

        int queriesCount = Convert.ToInt32(Console.ReadLine()?.Trim() ?? "0");

        List<string> queries = new List<string>();

        for (int i = 0; i < queriesCount; i++)
        {
            string queriesItem = Console.ReadLine() ?? "";
            queries.Add(queriesItem);
        }

        List<int> res = Result.matchingStrings(stringList, queries);

        Console.WriteLine(String.Join("\n", res));
    }
}

class Result
{
    public static List<int> matchingStrings(List<string> stringList, List<string> queries)
    {
        if (stringList is null)
        {
            throw new ArgumentNullException(nameof(stringList));
        }

        if (queries is null)
        {
            throw new ArgumentNullException(nameof(queries));
        }

        var queryMatchCount = new Dictionary<string, int>();
        foreach (var str in stringList)
        {
            if (queryMatchCount.ContainsKey(str))
            {
                queryMatchCount[str]++;
            }
            else
            {
                queryMatchCount[str] = 1;
            }
        }

        var result = new List<int>();
        foreach (var query in queries)
        {
            result.Add(queryMatchCount.ContainsKey(query) ? queryMatchCount[query] : 0);
        }

        return result;
    }
}
