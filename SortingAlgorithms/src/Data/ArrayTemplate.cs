namespace SortingAlgorithms.Data;

public static class ArrayTemplate
{
    public static (int length, int min, int max) Get(int templateId) => templateId switch
    {
        1 => (10_000, 1, 100),
        2 => (50_000, 1, 100),
        3 => (100_000, 1, 100),
        4 => (1_000_000, 1, 1000),
        _ => throw new ArgumentException("Invalid template ID")
    };
}
