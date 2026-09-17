namespace SortingAlgorithms.Algorithms;

public class ShellSort : ISortAlgorithm
{
    public string Name => "Shell sort";

    public void Sort(int[] array)
    {
        for (var gap = array.Length / 2; gap > 0; gap /= 2)
        for (var i = gap; i < array.Length; i++)
        {
            var temp = array[i];
            var j = i;
            while (j >= gap && array[j - gap] > temp)
            {
                array[j] = array[j - gap];
                j -= gap;
            }

            array[j] = temp;
        }
    }
}