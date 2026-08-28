namespace SortingAlgorithms.Ui;

public static class ConsoleUi
{
    public static int ChooseTemplate()
    {
        Console.WriteLine(
            "[1] -> Length 10 000\t\tValue range [1 - 100]\n" +
            "[2] -> Length 50 000\t\tValue range [1 - 100]\n" +
            "[3] -> Length 100 000\t\tValue range [1 - 100]\n" +
            "[4] -> Length 1 000 000\t\tValue range [1 - 1000]\n" +
            "\n" +
            "[9] -> Customize Data\n" +
            "[0] -> Exit the program\n" +
            "\n" +
            "Select a template or customize it to create the array: ");

        return int.Parse(Console.ReadLine()!);
    }

    public static (int length, int min, int max) GetCustomInput()
    {
        Console.WriteLine("\nEnter the length of the array and the minimum and maximum numbers to be generated, separated by commas: ");
        var input = Console.ReadLine()!;
        var parts = input.Split(',');
        return (int.Parse(parts[0]), int.Parse(parts[1]), int.Parse(parts[2]));
    }

    public static int ChooseAlgorithm()
    {
        Console.WriteLine(
            "\n[1] -> Selection sort\n" +
            "[2] -> Bubble sort\n" +
            "[3] -> Insertion sort\n" +
            "[4] -> Shell sort\n" +
            "\n" +
            "Choose a sorting algorithm: ");

        return int.Parse(Console.ReadLine()!);
    }

    public static void ShowStartMessage()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.CursorVisible = false;
        Console.WriteLine("\nSorting in progress, please wait...");
    }

    public static void ShowEndMessage()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.CursorVisible = true;
        Console.WriteLine("\nSorting Complete");
        Console.ForegroundColor = ConsoleColor.White;
    }

    public static void ShowExit()
    {
        Console.WriteLine("\nProgram terminated");
    }
}
