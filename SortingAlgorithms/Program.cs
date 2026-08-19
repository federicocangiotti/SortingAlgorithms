namespace SortingAlgorithms
{
    internal class Program
    {
        static AlgorithmsManager algorithms;

        static void Main(string[] args)
        {
            string arrayCreationMessage =
                "[1] -> Length 10 000\t\tValue range [1 - 100]\n" +
                "[2] -> Length 50 000\t\tValue range [1 - 100]\n" +
                "[3] -> Length 100 000\t\tValue range [1 - 100]\n" +
                "[4] -> Length 1 000 000\t\tValue range [1 - 1000]\n" +
                "\n" +
                "[9] -> Customize Data\n" +
                "[0] -> Exit the program\n" +
                "\n" +
                "Select a template or customize it to create the array: ";

            string algorithmSelectionMessage =
                "\n[1] -> Selection sort\n" +
                "[2] -> Bubble sort\n" +
                "[3] -> Insertion sort\n" +
                "[4] -> Shell sort\n" +
                "\n" +
                "Choose a sorting algorithm: ";

            do
            {
                int length, nMin, nMax, selectedAlgorithm;
                length = nMin = nMax = 0;

                Console.WriteLine(arrayCreationMessage);
                int arrayCreationChoice = Convert.ToInt32(Console.ReadLine());
                if (arrayCreationChoice == 0)
                {
                    Console.WriteLine("\nProgram terminated");
                    break;
                }
                switch (arrayCreationChoice)
                {
                    case 1:
                        length = 10000;
                        nMin = 1;
                        nMax = 100;
                        break;
                    case 2:
                        length = 50000;
                        nMin = 1;
                        nMax = 100;
                        break;
                    case 3:
                        length = 100000;
                        nMin = 1;
                        nMax = 100;
                        break;
                    case 4:
                        length = 1000000;
                        nMin = 1;
                        nMax = 1000;
                        break;
                    case 9:
                        Console.WriteLine("\nEnter the length of the array and the minimum and maximum numbers to be generated, separated by commas: ");
                        string vectorProperties = Console.ReadLine();
                        SplitFeaturesArray(vectorProperties, ref length, ref nMin, ref nMax);
                        break;
                    default:
                        Console.WriteLine("Invalid selection; please restart the program");
                        break;
                }
                algorithms = new AlgorithmsManager(length, nMin, nMax);

                Console.WriteLine(algorithmSelectionMessage);
                selectedAlgorithm = Convert.ToInt32(Console.ReadLine());
                switch (selectedAlgorithm)
                {
                    case 1:
                        MessageStartSorting();
                        algorithms.SelectionSort();
                        break;
                    case 2:
                        MessageStartSorting();
                        algorithms.BubbleSort();
                        break;
                    case 3:
                        MessageStartSorting();
                        algorithms.InsertionSort();
                        break;
                    case 4:
                        MessageStartSorting();
                        algorithms.ShellSort();
                        break;
                    default:
                        Console.WriteLine("Invalid selection; please restart the program");
                        break;
                }
                MessageEndSorting();
                Console.WriteLine(algorithms.executionTime);
                Console.WriteLine("\n------------------------------------------------------------------------------------------\n");
            } while (true);
        }

        static void SplitFeaturesArray(string input, ref int length, ref int min, ref int max)
        {
            string[] ris = input.Split(",");
            length = Convert.ToInt32(ris[0]);
            min = Convert.ToInt32(ris[1]);
            max = Convert.ToInt32(ris[2]);
        }

        static void MessageStartSorting()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.CursorVisible = false;
            Console.WriteLine("\nSorting in progress, please wait...");
        }

        static void MessageEndSorting()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.CursorVisible = true;
            Console.WriteLine("\nSorting Complete");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
