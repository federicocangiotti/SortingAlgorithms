using System.Diagnostics;
using SortingAlgorithms.Algorithms;
using SortingAlgorithms.Data;
using SortingAlgorithms.Ui;

while (true)
{
    /* Initial message */
    var templateChoice = ConsoleUi.ChooseTemplate();

    /* Exit program if user chooses to do so */
    if (templateChoice == 0)
    {
        ConsoleUi.ShowExit();
        break;
    }

    /* Get array traits (length, min, max) for sorting based on user choice */
    var (length, min, max) = templateChoice == 9
        ? ConsoleUi.GetCustomInput()
        : ArrayTemplate.Get(templateChoice);

    /* Select algorithm choice from user */
    var algorithmChoice = ConsoleUi.ChooseAlgorithm();
    var algorithm = AlgorithmRegistry.Get(algorithmChoice);

    /* Check if algorithm exists */
    if (algorithm is null)
    {
        Console.WriteLine("\nInvalid selection; please restart the program\n");
        Console.WriteLine("\n------------------------------------------------------------------------------------------\n");
        continue;
    }

    /* Generate array based on template choice */
    var array = ArrayGenerator.Generate(length, min, max);

    ConsoleUi.ShowStartMessage();

    /* Sorting */
    var sw = Stopwatch.StartNew();
    algorithm.Sort(array);
    sw.Stop();

    ConsoleUi.ShowEndMessage();

    Console.WriteLine($"\nExecution time (hh:mm:ss.ms) - {sw.Elapsed.Hours}:{sw.Elapsed.Minutes}:{sw.Elapsed.Seconds}.{sw.Elapsed.Milliseconds}");

    Console.WriteLine("\n------------------------------------------------------------------------------------------\n");
}