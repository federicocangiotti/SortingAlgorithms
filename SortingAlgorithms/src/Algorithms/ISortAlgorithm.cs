namespace SortingAlgorithms.Algorithms;

public interface ISortAlgorithm
{
    string Name { get; }
    void Sort(int[] array);
}
