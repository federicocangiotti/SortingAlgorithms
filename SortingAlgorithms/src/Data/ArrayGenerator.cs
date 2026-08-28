namespace SortingAlgorithms.Data;

public static class ArrayGenerator
{
    public static int[] Generate(int length, int min, int max)
    {
        var random = new Random();
        var array = new int[length];
        for (int i = 0; i < length; i++)
        {
            array[i] = random.Next(min, max + 1);
        }
        return array;
    }
}
