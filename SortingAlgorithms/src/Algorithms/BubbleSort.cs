namespace SortingAlgorithms.Algorithms;

public class BubbleSort : ISortAlgorithm
{
    public string Name => "Bubble sort";

    public void Sort(int[] array)
    {
        bool swapped = true;
        int end = array.Length - 1;
        while (swapped)
        {
            swapped = false;
            for (int i = 0; i < end; i++)
            {
                if (array[i] > array[i + 1])
                {
                    (array[i], array[i + 1]) = (array[i + 1], array[i]);
                    swapped = true;
                }
            }
            end--;
        }
    }
}
