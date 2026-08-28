namespace SortingAlgorithms.Algorithms;

public static class AlgorithmRegistry
{
    private static readonly Dictionary<int, ISortAlgorithm> Algorithms = new()
    {
        [1] = new SelectionSort(),
        [2] = new BubbleSort(),
        [3] = new InsertionSort(),
        [4] = new ShellSort()
    };

    public static ISortAlgorithm? Get(int key) => Algorithms.TryGetValue(key, out var algorithm) ? algorithm : null;
}
