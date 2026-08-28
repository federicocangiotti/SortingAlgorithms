namespace SortingAlgorithms.Algorithms;

public class SelectionSort : ISortAlgorithm
{
    public string Name => "Selection sort";

    public void Sort(int[] array)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            int min = i;
            for (int j = i + 1; j < array.Length; j++)
            {
                if (array[j] < array[min]) min = j;
            }
            if (min != i) (array[i], array[min]) = (array[min], array[i]);
        }
    }
}
