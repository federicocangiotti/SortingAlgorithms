namespace SortingAlgorithms.Algorithms;

public class SelectionSort : ISortAlgorithm
{
    public string Name => "Selection sort";

    public void Sort(int[] array)
    {
        for (var i = 0; i < array.Length - 1; i++)
        {
            var min = i;
            for (var j = i + 1; j < array.Length; j++)
                if (array[j] < array[min])
                    min = j;
            if (min != i) (array[i], array[min]) = (array[min], array[i]);
        }
    }
}