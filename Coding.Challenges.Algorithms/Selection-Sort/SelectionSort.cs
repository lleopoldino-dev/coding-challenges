using System.Collections.Generic;

namespace Coding.Challenges.Algorithms.Selection_Sort;

public class SelectionSort
{
    public static void Execute(List<int> list, bool recursive = false)
    {
        if (recursive)
        {
            ExecuteSelectionSort(list);
        }
        else
        {
            ExecuteSelectionSortRecursive(list, list.Count, 0);
        }


        Console.WriteLine(string.Join(", ", list));
    }

    public static void ExecuteSelectionSort(List<int> list)
    {
        for (int i = 0; i < list.Count - 1; i++)
        {
            var minIndex = i;

            for (int j = i + 1; j < list.Count - 1; j++)
            {
                if (list[j] < list[minIndex]) 
                { 
                    minIndex = j;
                }
            }

            var temp = list[i];
            list[minIndex] = list[i];
            list[i] = temp;
        }
    }

    public static void ExecuteSelectionSortRecursive(List<int> list, int arrLength, int startIndex)
    {
        if(arrLength == startIndex)
        {
            return;
        }

        var minIndex = MinIndex(list, startIndex, arrLength - 1);

        if (minIndex != startIndex)
        {
            var temp = list[minIndex];
            list[minIndex] = list[startIndex];
            list[startIndex] = temp;
        }
        
        ExecuteSelectionSortRecursive(list, arrLength, startIndex + 1);
    }

    private static int MinIndex(List<int> list, int index, int arraySize)
    {
        if (index == arraySize)
        {
            return index;
        }

        int minIndex = MinIndex(list, index + 1, arraySize);

        return list[index] < list[minIndex] ? index : minIndex;
    }
}
